using System.Formats.Asn1;
using System.Security;
using Fire_Emblem_View;

using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.IO.Pipes;
namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    public List<Player> players;
    private int _turn;
    private int _round;

    private Scope _scope;


    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;
        players = new List<Player>();
        _round = 1;
        _turn = 0;
    }

    public void Play() {
        SelectTeam();
        if (!AreTeamsValid()) {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }
        while (!IsGameOver()) {
            PlayRound();
        }
        AnounceWinner();

    }

    void PlayRound() {
        SelectPlayers();
        Fight();
        EndRoundClenup();
    }

    void EndRoundClenup() {
        _turn = (_turn + 1) & 1;
        _round += 1;
        Fighter(1).SetLatestOpponent(Fighter(0));
        Fighter(0).SetLatestOpponent(Fighter(1));
        players[0].ClearFighter();
        players[1].ClearFighter();
    }

    bool IsGameOver() {
        return players.Any((player) => player.HasLost());
    }

    void AnounceWinner() {
        int winner = players[0].HasLost() ? 2 : 1;
        _view.AnounceWinner(winner);
    }

    void SelectPlayers() {
        foreach (var i in TurnIter()) {
            _view.WriteLine($"Player {i + 1} selecciona una opción");
            _view.WriteLine(players[i].UnitOptions());
            players[i].SetFighter(Int32.Parse(_view.ReadLine()));
        }
    }

    private IEnumerable<int> TurnIter() {
        if (_turn == 0)
            return [0, 1];
        else return [1, 0];
    }



    void Fight() {
        _scope = Scope.FIRST_ATTACK;
        AnounceFightStarts();
        AnounceAdvantage();
        SetupEffects();
        LaunchAttack();
        if (Defender().IsAlive()) {
            RetaliateAttack();
        } else {
            FightResults();
            return;
        }
        if (Attacker().IsAlive()) {
            _scope = Scope.FOLLOW_UP;
            FollowUp();
        }
        FightResults();
    }

    void FightResults() {
        _view.WriteLine($"{Attacker()} ({Attacker().GetHP()}) : {Defender()} ({Defender().GetHP()})");
    }

    void FollowUp() {
        if (Defender().Get(Stat.Spd) + 5 <= Attacker().Get(Stat.Spd)) {
            LaunchAttack();
        } else if (Attacker().Get(Stat.Spd) + 5 <= Defender().Get(Stat.Spd)) {
            RetaliateAttack();
        } else {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    public bool IsPlayersTurn(int player) {
        return _turn == (player & 1);
    }

    void LaunchAttack() {
        int damage = Attacker().Attack(Defender(), _scope);
        _view.AnounceAttack(Attacker(), Defender(), damage);
    }

    void RetaliateAttack() {
        int damage = Defender().Attack(Attacker(), _scope);
        _view.AnounceAttack(Defender(), Attacker(), damage);
    }

    void AnounceFightStarts() {
        _view.AnounceFightStarts(_round, Attacker(), _turn + 1);
    }

    void SetupEffects() {
        foreach (var i in TurnIter()) {
            SetupEffectsForPlayer(i, EffectDependency.None);
        }

        foreach (var i in TurnIter()) {
            SetupEffectsForPlayer(i, EffectDependency.Stats);
        }

        foreach (var i in TurnIter()) {
            AnounceEffectsForPlayer(i);
        }
    }

    private void AnounceEffectsForPlayer(int player) {
        AnounceStatEfectForPlayer(player, EffectType.Bonus);
        AnounceStatEfectForPlayer(player, EffectType.Penalty);
        AnounceNeutralizedEffectsForPlayer(player, EffectType.Bonus);
        AnounceNeutralizedEffectsForPlayer(player, EffectType.Penalty);
        AnounceDamageEffectsForPlayer(player);
    }

    private void AnounceDamageEffectsForPlayer(int player) {
        var fighter = Fighter(player);
        var reduction = fighter.GetTotalPercentDamageReduction(Scope.ALL);
        _view.AnouncePercentEffect(fighter, reduction);
        reduction = fighter.GetTotalPercentDamageReduction(Scope.FIRST_ATTACK);
        _view.AnouncePercentEffectFirstAttack(fighter, reduction);
    }

    private void AnounceStatEfectForPlayer(int player, EffectType effectType) {
        var unit = Fighter(player);
        foreach (var stat in StatConstants.ORDERED) {
            var value = unit.GetEffectFor(stat, effectType);
            _view.AnounceStatEffect(unit, stat, value);
        }
    }

    private void AnounceNeutralizedEffectsForPlayer(int player, EffectType effectType) {
        var unit = Fighter(player);
        foreach (var stat in StatConstants.ORDERED) {
            if (unit.IsNeutralized(stat, effectType))
                _view.AnounceNeutralizedEffect(unit, stat, effectType);
        }
    }


    void SetupEffectsForPlayer(int player, EffectDependency dependency) {
        foreach (var skill in ForSkillInFighter(player)) {
            skill.Install(this, player, dependency);
        }
    }


    private IEnumerable<Skill> ForSkillInFighter(int player) {
        var fighter = players[player].GetFighter();
        foreach (var skill in fighter.GetSkills()) {
            yield return skill;
        }
    }

    public Unit Fighter(int player) {
        return players[player & 1].GetFighter();
    }



    void AnounceAdvantage() {
        if (Attacker().HasAdvantageOver(Defender())) {
            _view.WriteLine($"{Attacker()} ({Attacker().GetWeapon()}) tiene ventaja con respecto a {Defender()} ({Defender().GetWeapon()})");
        } else if (Defender().HasAdvantageOver(Attacker())) {
            _view.WriteLine($"{Defender()} ({Defender().GetWeapon()}) tiene ventaja con respecto a {Attacker()} ({Attacker().GetWeapon()})");
        } else {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public Unit Attacker() {
        return Fighter(_turn);
    }

    public Unit Defender() {
        return Fighter(_turn + 1);
    }


    void SelectTeam() {
        List<string> options = WriteSelectTreamOptions();
        int answer = Int32.Parse(_view.ReadLine());
        LoadTeams(options[answer]);
    }

    List<string> WriteSelectTreamOptions() {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        var list = Directory.EnumerateFiles(_teamsFolder, "*.txt").ToList();
        list.Sort();
        foreach (var (index, file) in list.Enumerate()) {
            _view.WriteLine($"{index}: {Path.GetFileName(file)}");
        }
        return list;
    }

    static Regex PLAYER_LINE = new Regex(@"Player [12] Team");

    static Regex UNIT_LINE = new Regex(@"^([^)]+)(?:| \(([^)]+)\))$");


    void LoadTeams(string file) {
        foreach (var line in File.ReadLines(file)) {
            addPlayerFromFileLine(line);
        }
    }

    void addPlayerFromFileLine(string line) {
        if (PLAYER_LINE.Match(line).Success) {
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

