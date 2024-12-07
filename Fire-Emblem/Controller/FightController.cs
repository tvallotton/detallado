using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Fire_Emblem;
using Fire_Emblem_View;

class FightController(GameState _game, FireEmblemView _view) {

    private Scope _scope = Scope.FIRST_ATTACK;


    public void Fight() {
        AnnounceFightStarts();
        AnnounceAdvantage();
        SetupEffects();
        LaunchAttacks();
        PostFightEffects();
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
    }



    private void HealFighter(Unit fighter) {
        _view.AnnounceHealedFighter(fighter, fighter.InCombatHeal());
    }

    public void ApplyAfterCombatDamage() {

        foreach (var player in IterOverTurns()) {
            var unit = _game.GetFighter(player);
            var rival = _game.GetFighter(player + 1);
            var damage = unit.SumEffects(EffectName.DamageAfterCombat);
            damage = Math.Min(damage, rival.GetHP() - 1);
            if (damage != 0 && rival.IsAlive()) {
                rival.TakeDamage(damage);
                _view.AnnounceAfterCombatDamage(rival, damage);
                Trace.Assert(rival.GetHP() > 0);
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
        var counterAttackIsBlocked = (
            Attacker().HasEffect(EffectName.CounterAttackNegation) &&
            !Defender().HasEffect(EffectName.CounterAttacKNegationBlocker)
        );
        return Defender().IsAlive() && !counterAttackIsBlocked;
    }

    private bool CanFollowUp(Unit unit, Unit against) {
        return against.GetStat(Stat.Spd) + 5 <= unit.GetStat(Stat.Spd);

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
        foreach (var dependency in Enum.GetValues<EffectDependency>()) {
            foreach (var player in IterOverTurns()) {
                SetupEffectsForPlayer(player, dependency);
            }
        }

        foreach (var player in IterOverTurns()) {
            new EffectAnnouncer(_view, player, _game).AnnounceEffects();
        }

        foreach (var player in IterOverTurns()) {
            new EffectAnnouncer(_view, player, _game).AnnounceBeforeCombatDamage();
        }
    }

    private void PostFightEffects() {


        foreach (var player in IterOverTurns()) {

            PerformDamageAfterCombat(player);
            PerformHealingAftercCombat(player);
            new EffectAnnouncer(_view, player, _game).AnnounceAfterCombatEffects();
        }
    }

    private void PerformDamageAfterCombat(int player) {
        var fighter = _game.GetFighter(player);
        int rawDamage = fighter.SumEffects(EffectName.DamageAfterCombat);

        int actualDamage = Math.Min(rawDamage, fighter.GetHP() - 1);

        if (fighter.IsAlive()) {
            fighter.TakeDamage(actualDamage);

        }
    }

    private void PerformHealingAftercCombat(int player) {
        var fighter = _game.GetFighter(player);
        int healing = fighter.SumEffects(EffectName.HealingAfterCombat);

        if (fighter.IsAlive())
            fighter.Heal(healing);


    }

    private void SetupEffectsForPlayer(int player, EffectDependency dependency) {

        foreach (var skill in ForSkillInFighter(player)) {
            skill.Register(_game, player, dependency);
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