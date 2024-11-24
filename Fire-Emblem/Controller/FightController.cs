using Fire_Emblem;
using Fire_Emblem_View;

class FightController(GameState _game, FireEmblemView _view) {

    private Scope _scope = Scope.FIRST_ATTACK;


    public void Fight() {
        AnnounceFightStarts();
        AnnounceAdvantage();
        SetupEffects();
        LaunchAttacks();
        _view.AnnounceFightResults(Attacker(), Defender());
    }

    public void LaunchAttacks() {
        _scope = Scope.FIRST_ATTACK;
        LaunchAttack();
        if (CanCounterAttack()) {
            LaunchCounterAttack();
        } else if (!Defender().IsAlive()) {
            return;
        }

        if (Attacker().IsAlive()) {
            _scope = Scope.FOLLOW_UP;
            FollowUp();
        }
        ApplyAfterCombatDamage();

    }



    private void HealFighter(Unit fighter) {
        _view.AnnounceHealedFighter(fighter, fighter.Heal());
    }

    public void ApplyAfterCombatDamage() {
        foreach (var player in IterOverTurns()) {
            var unit = _game.GetFighter(player);
            var rival = _game.GetFighter(player + 1);
            var damage = unit.SumEffects(EffectName.DamageAfterCombat);
            if (damage != 0) {
                rival.TakeDamage(unit.SumEffects(EffectName.DamageAfterCombat));
                _view.AnnounceAfterCombatDamage(rival, damage);
            }
        }
    }

    private void FollowUp() {
        if (CanFollowUp(Attacker(), against: Defender())) {
            LaunchAttack();
        } else if (CanFollowUp(Defender(), against: Attacker()) && CanCounterAttack()) {
            LaunchCounterAttack();
        } else if (CanCounterAttack()) {
            _view.AnnounceNoFollowUp();
        } else {
            _view.AnnouncePlayerCannotFolowUp(Attacker());
        }
    }


    private void LaunchAttack() {
        int damage = Attacker().Attack(Defender(), _scope);
        _view.AnnounceAttack(Attacker(), Defender(), damage);
        HealFighter(Attacker());
    }

    private bool CanCounterAttack() {
        return (
            Defender().IsAlive() &&
            !Attacker().HasEffect(EffectName.CounterAttackNegation) &&
            !Defender().HasEffect(EffectName.CounterAttacKNegationBlocker)
        );
    }

    private bool CanFollowUp(Unit unit, Unit against) {
        return against.Get(Stat.Spd) + 5 <= unit.Get(Stat.Spd);

    }

    private void LaunchCounterAttack() {
        int damage = Defender().Attack(Attacker(), _scope);
        _view.AnnounceAttack(Defender(), Attacker(), damage);
        HealFighter(Defender());
    }

    private void AnnounceFightStarts() {
        _view.AnnounceFightStarts(_game.round, Attacker(), _game.turn + 1);
    }

    private void SetupEffects() {
        foreach (var player in IterOverTurns()) {
            SetupEffectsForPlayer(player, EffectDependency.None);
        }

        foreach (var player in IterOverTurns()) {
            SetupEffectsForPlayer(player, EffectDependency.Stats);
        }

        foreach (var player in IterOverTurns()) {
            new EffectAnnouncer(_view, player, _game).AnnounceEffects();
        }

    }

    private void SetupEffectsForPlayer(int player, EffectDependency dependency) {
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


    private void AnnounceAdvantage() {
        if (Attacker().HasAdvantageOver(Defender())) {
            _view.AnnounceAdvantage($"{Attacker()} ({Attacker().GetWeapon()})", $"{Defender()} ({Defender().GetWeapon()})");
        } else if (Defender().HasAdvantageOver(Attacker())) {
            _view.AnnounceAdvantage($"{Defender()} ({Defender().GetWeapon()})", $"{Attacker()} ({Attacker().GetWeapon()})");
        } else {
            _view.AnnounceNoAdvantage();
        }
    }

    private Unit Attacker() {
        return _game.GetFighter(_game.turn);
    }

    private Unit Defender() {
        return _game.GetFighter(_game.turn + 1);
    }

    private IEnumerable<int> IterOverTurns() {
        return _game.IterOverTurns();
    }
}