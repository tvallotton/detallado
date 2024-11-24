
using Fire_Emblem_View;
using Fire_Emblem_Model;
using System.Text.RegularExpressions;

namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    private GameState _gameState;

    private int FOLLOW_UP_DIFFERENCE = 5;

    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;
        _gameModel = new GameState();
    }

    public void Play() {
        SelectTeams();
        if (!AreTeamsValid()) {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }
        while (!IsGameModelOver()) {
            PlayRound();
        }
        AnnounceWinner();

    }

    void PlayRound() {
        SelectPlayers();
        Fight();
        EndRoundClenup();
    }

    void EndRoundClenup() {
        _turn = (_turn + 1) & 1;
        _round += 1;
        GetFighter(1).SetLatestOpponent(GetFighter(0));
        GetFighter(0).SetLatestOpponent(GetFighter(1));
        players[0].ClearFighter();
        players[1].ClearFighter();
    }

    bool IsGameModelOver() {
        return players.Any((player) => player.HasLost());
    }

    void AnnounceWinner() {
        int winner = players[0].HasLost() ? 2 : 1;
        _view.AnnounceWinner(winner);
    }

    void SelectPlayers() {
        foreach (var i in TurnIter()) {
            var choice = _view.AskToSelectAnOption(i, players[i].LivingUnits());
            players[i].SetFighter(choice);
        }
    }

    private IEnumerable<int> TurnIter() {
        if (_turn == 0)
            return [0, 1];
        else return [1, 0];
    }



    void Fight() {
        _scope = Scope.FIRST_ATTACK;
        AnnounceFightStarts();
        AnnounceAdvantage();
        SetupEffects();
        LaunchAttack();
        if (GetDefender().IsAlive()) {
            RetaliateAttack();
        } else {
            FightResults();
            return;
        }
        if (GetAttacker().IsAlive()) {
            _scope = Scope.FOLLOW_UP;
            FollowUp();
        }
        FightResults();
    }

    void FightResults() {
        _view.WriteLine($"{GetAttacker()} ({GetAttacker().GetHP()}) : {GetDefender()} ({GetDefender().GetHP()})");
    }

    void FollowUp() {
        if (GetDefender().GetStat(Stat.Spd) + FOLLOW_UP_DIFFERENCE <= GetAttacker().GetStat(Stat.Spd)) {
            LaunchAttack();
        } else if (GetAttacker().GetStat(Stat.Spd) + FOLLOW_UP_DIFFERENCE <= GetDefender().GetStat(Stat.Spd)) {
            RetaliateAttack();
        } else {
            _view.AnnounceNoFollowUp();
        }
    }

    public bool IsPlayersTurn(int player) {
        return _turn == (player & 1);
    }



    void LaunchAttack() {
        int damage = GetAttacker().Attack(GetDefender(), _scope);
        _view.AnnounceAttack(GetAttacker(), GetDefender(), damage);

    }

    void RetaliateAttack() {
        int damage = GetDefender().Attack(GetAttacker(), _scope);
        _view.AnnounceAttack(GetDefender(), GetAttacker(), damage);
    }





    void AnnounceFightStarts() {
        _view.AnnounceFightStarts(_round, GetAttacker(), _turn + 1);
    }

    void SetupEffects() {
        foreach (var player in TurnIter()) {
            SetupEffectsForPlayer(player, EffectDependency.None);
        }

        foreach (var player in TurnIter()) {
            SetupEffectsForPlayer(player, EffectDependency.Stats);
        }

        foreach (var player in TurnIter()) {
            AnnounceEffectsForPlayer(player);
        }
    }

    private void AnnounceEffectsForPlayer(int player) {
        Action<int, EffectType>[] announcements = [AnnounceStatEffectsForPlayer, AnnounceNeutralizedEffectsForPlayer];
        foreach (var func in announcements) {
            func(player, EffectType.Bonus);
            func(player, EffectType.Penalty);
        }
        AnnounceDamageEffectsForPlayer(player);

    }

    private void AnnounceDamageEffectsForPlayer(int player) {
        var fighter = GetFighter(player);
        AnnounceExtraDamageEffects(fighter);
        AnnouncePercentDamageReduction(fighter);
        AnnounceAbsoluteDamageReductionEffects(fighter);
    }

    private void AnnouncePercentDamageReduction(Unit fighter) {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetTotalPercentDamageReduction(scope);
            _view.AnnouncePercentEffect(fighter, reduction, scope);
        }
    }

    private void AnnounceExtraDamageEffects(Unit fighter) {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var damage = fighter.GetExtraDamage(scope);
            _view.AnnounceExtraDamageEffect(fighter, damage, scope);
        }
    }

    private void AnnounceAbsoluteDamageReductionEffects(Unit fighter) {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetAbsoluteDamageReduction(scope);
            _view.AnnounceAbsoluteDamageReduction(fighter, reduction, scope);
        }
    }

    private void AnnounceStatEffectsForPlayer(int player, EffectType effectType) {
        var unit = GetFighter(player);
        foreach (var scope in Enum.GetValues<Scope>()) {
            AnnounceStatEffectsForScope(unit, effectType, scope);
        }
    }

    private void AnnounceStatEffectsForScope(Unit unit, EffectType effectType, Scope scope) {
        foreach (var stat in StatConstants.ORDERED) {
            var value = unit.GetEffectFor(stat, effectType, (effect) => effect.scope == scope);
            switch (scope) {
                case Scope.ALL: _view.AnnounceStatEffect(unit, stat, value); break;
                case Scope.FIRST_ATTACK: _view.AnnounceStatEffectFirstAttack(unit, stat, value); break;
                case Scope.FOLLOW_UP: _view.AnnounceStatEffectFollowUp(unit, stat, value); break;
            };
        }
    }

    private void AnnounceNeutralizedEffectsForPlayer(int player, EffectType effectType) {
        var unit = GetFighter(player);
        foreach (var stat in StatConstants.ORDERED) {
            if (unit.IsNeutralized(stat, effectType))
                _view.AnnounceNeutralizedEffect(unit, stat, effectType);
        }
    }


    void SetupEffectsForPlayer(int player, EffectDependency dependency) {
        foreach (var skill in ForSkillInFighter(player)) {
            skill.Register(this, player, dependency);
        }
    }


    private IEnumerable<Skill> ForSkillInFighter(int player) {
        var fighter = players[player].GetFighter();
        foreach (var skill in fighter.GetSkills()) {
            yield return skill;
        }
    }

    public Unit GetFighter(int player) {
        return players[player & 1].GetFighter();
    }


    void AnnounceAdvantage() {
        if (GetAttacker().HasAdvantageOver(GetDefender())) {
            _view.AnnounceAdvantage($"{GetAttacker()} ({GetAttacker().GetWeapon()})", $"{GetDefender()} ({GetDefender().GetWeapon()})");
        } else if (GetDefender().HasAdvantageOver(GetAttacker())) {
            _view.AnnounceAdvantage($"{GetDefender()} ({GetDefender().GetWeapon()})", $"{GetAttacker()} ({GetAttacker().GetWeapon()})");
        } else {
            _view.AnnounceNoAdvantage();
        }
    }

    public Unit GetAttacker() {
        return GetFighter(_turn);
    }

    public Unit GetDefender() {
        return GetFighter(_turn + 1);
    }


    void SelectTeams() {
        List<string> options = _view.WriteSelectTeamOptions(_teamsFolder);
        int choice = Int32.Parse(_view.ReadLine());
        LoadTeams(options[choice]);
    }



    static Regex PLAYER_LINE = new Regex(@"Player [12] Team");

    static Regex UNIT_LINE = new Regex(@"^([^)]+)(?:| \(([^)]+)\))$");


    void LoadTeams(string file) {
        foreach (var line in File.ReadLines(file)) {
            AddPlayerFromFileLine(line);
        }
    }

    void AddPlayerFromFileLine(string line) {
        if (PLAYER_LINE.Match(line).Success) {
            _gameState.
            players.Add(new Player());
            return;
        }

        var unitMatch = UNIT_LINE.Match(line);

        var unitName = unitMatch.Groups[1].Value;
        var unitSkills = unitMatch.Groups[2].Value.Split(",");
        
        players.Last().AddUnit(new Unit(unitName, unitSkills));
    }


    bool AreTeamsValid() {

        
        foreach (var player in players) {
            if (!player.IsTeamValid()) {
                return false;
            }
        }
        return true;
    }
}

