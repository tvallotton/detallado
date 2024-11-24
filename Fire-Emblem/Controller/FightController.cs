using Fire_Emblem;
using Fire_Emblem_View;

class FightController(GameState _game, View _view) {

    private Scope _scope = Scope.FIRST_ATTACK;


    public void Fight() {
        _scope = Scope.FIRST_ATTACK;
        AnnounceFightStarts();
        AnnounceAdvantage();
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
            _view.AnnounceNoFollowUp();
        }
    }
    public bool IsPlayersTurn(int player) {
        return _game.turn == (player & 1);
    }

    void LaunchAttack() {
        int damage = Attacker().Attack(Defender(), _scope);
        _view.AnnounceAttack(Attacker(), Defender(), damage);
    }

    void RetaliateAttack() {
        int damage = Defender().Attack(Attacker(), _scope);
        _view.AnnounceAttack(Defender(), Attacker(), damage);
    }

    void AnnounceFightStarts() {
        _view.AnnounceFightStarts(_game.round, Attacker(), _game.turn + 1);
    }

    void SetupEffects() {
        foreach (var player in IterOverTurns()) {
            SetupEffectsForPlayer(player, EffectDependency.None);
        }

        foreach (var player in IterOverTurns()) {
            SetupEffectsForPlayer(player, EffectDependency.Stats);
        }

        foreach (var player in IterOverTurns()) {
            new EffectAnnouncer(_view, _game.GetFighter(player)).AnnounceEffectsForPlayer();
        }
    }

    void SetupEffectsForPlayer(int player, EffectDependency dependency) {
        foreach (var skill in ForSkillInFighter(player)) {
            skill.Install(_game, player, dependency);
        }
    }


    private IEnumerable<Skill> ForSkillInFighter(int player) {
        var fighter = _game.GetFighter(player);
        foreach (var skill in fighter.GetSkills()) {
            yield return skill;
        }
    }


    void AnnounceAdvantage() {
        if (Attacker().HasAdvantageOver(Defender())) {
            _view.AnnounceAdvantage($"{Attacker()} ({Attacker().GetWeapon()})", $"{Defender()} ({Defender().GetWeapon()})");
        } else if (Defender().HasAdvantageOver(Attacker())) {
            _view.AnnounceAdvantage($"{Defender()} ({Defender().GetWeapon()})", $"{Attacker()} ({Attacker().GetWeapon()})");
        } else {
            _view.AnnounceNoAdvantage();
        }
    }

    public Unit Attacker() {
        return _game.GetFighter(_game.turn);
    }

    public Unit Defender() {
        return _game.GetFighter(_game.turn + 1);
    }

    private IEnumerable<int> IterOverTurns() {
        return _game.IterOverTurns();
    }
}