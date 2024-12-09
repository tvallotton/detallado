using System.Collections;
using Fire_Emblem_View;

public class EffectAnnouncer(FireEmblemView _view, int player, GameState _gameState) {

    Unit unit = _gameState.GetFighter(player);
    Unit rival = _gameState.GetFighter(player + 1);



    public void AnnounceEffects() {
        Action<EffectType>[] announcements = [AnnounceStatEffects, AnnounceNeutralizedEffects];
        foreach (var func in announcements) {
            func(EffectType.Bonus);
            func(EffectType.Penalty);
        }

        AnnounceAllDamageEffects();
        AnnounceByEffectName(EffectName.Healing);
        AnnounceByEffectName(EffectName.FollowUpNegation);
        AnnounceByEffectName(EffectName.FollowUpGuarantee);
        AnnounceByEffectName(EffectName.OffensiveNullFollowUp);
        AnnounceByEffectName(EffectName.DefensiveNullFollowUp);
        AnnounceCounterAttackNegation();
        AnnounceCounterAttackNegationBlocker();
    }

    public void AnnounceAfterCombatEffects() {

        AnnounceByEffectName(EffectName.DamageAfterCombat);
        AnnounceByEffectName(EffectName.HealingAfterCombat);
    }

    private void AnnounceAllDamageEffects() {
        AnnounceExtraDamageEffects();
        AnnouncePercentDamageReduction();
        AnnounceAbsoluteDamageReductionEffects();

    }





    private void AnnounceCounterAttackNegation() {
        var isPlayersTurn = _gameState.IsPlayersTurn(player);
        var hasCounterAttackNegation = unit.HasEffect(EffectName.CounterAttackNegation);
        var rivalHasCounterAttackNegationBlocker = !rival.HasEffect(EffectName.CounterAttacKNegationBlocker);
        if (isPlayersTurn && hasCounterAttackNegation && rivalHasCounterAttackNegationBlocker)
            _view.AnnounceCounterAttackNegation(rival);
    }




    private void AnnouncePercentDamageReduction() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = unit.GetTotalPercentDamageReduction(scope);
            _view.AnnouncePercentEffect(unit, reduction, scope);
        }
    }
    private void AnnounceExtraDamageEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var damage = unit.GetExtraDamage(scope);
            _view.AnnounceExtraDamageEffect(unit, damage, scope);
        }
    }


    private void AnnounceCounterAttackNegationBlocker() {
        var hasCounterAttackNegationBlocker = unit.HasEffect(EffectName.CounterAttacKNegationBlocker);
        var rivalHasCounterAttackNegation = rival.HasEffect(EffectName.CounterAttackNegation);
        var isPlayersTurn = _gameState.IsPlayersTurn(player);
        if (!isPlayersTurn && rivalHasCounterAttackNegation && hasCounterAttackNegationBlocker) {
            _view.AnnounceCounterAttackNegationBlocker(unit);
        }
    }

    private void AnnounceAbsoluteDamageReductionEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = unit.GetAbsoluteDamageReduction(scope);
            _view.AnnounceAbsoluteDamageReduction(unit, reduction, scope);
        }
    }

    private void AnnounceStatEffects(EffectType effectType) {

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

    private void AnnounceNeutralizedEffects(EffectType effectType) {
        foreach (var stat in StatConstants.ORDERED) {
            if (unit.IsNeutralized(stat, effectType))
                _view.AnnounceNeutralizedEffect(unit, stat, effectType);
        }
    }
    public void AnnounceBeforeCombatDamage() {
        if (unit.HasEffect(EffectName.DamageBeforeCombat) && unit.IsAlive()) {
            int damage = unit.SumEffects(EffectName.DamageBeforeCombat);
            int realDamage = Math.Min(damage, unit.GetHP() - 1);
            unit.TakeDamage(realDamage);
            _view.AnnounceBeforeCombatDamage(unit, damage);
        }
    }


    private void AnnounceByEffectName(EffectName effectName) {
        switch (effectName) {
            case EffectName.FollowUpNegation:
                int effectValue = rival.SumEffects(effectName);
                if (effectValue == 0) return;
                _view.AnnounceFollowUpNegation(unit, effectValue); break;
            default:
                AnnounceByEffectNameForUnit(effectName); break;
        }
    }

    private void AnnounceByEffectNameForUnit(EffectName effectName) {
        int effectValue = unit.SumEffects(effectName);
        if (effectValue == 0) return;
        if (!unit.IsAlive()) return;
        switch (effectName) {
            case EffectName.DamageAfterCombat:
                _view.AnnounceAfterCombatDamage(unit, effectValue); break;
            case EffectName.HealingAfterCombat:
                _view.AnnounceAfterCombatHealing(unit, effectValue); break;
            case EffectName.DamageBeforeCombat:
                _view.AnnounceBeforeCombatDamage(unit, effectValue); break;
            case EffectName.FollowUpGuarantee:
                _view.AnnounceFollowUpGuarantees(unit, effectValue); break;
            case EffectName.DefensiveNullFollowUp:
                _view.AnnounceDefensiveNullFollowUp(unit); break;
            case EffectName.Healing:
                _view.AnnounceHealingEffect(unit, effectValue); break;
            case EffectName.OffensiveNullFollowUp:
                _view.AnnounceOffensiveNullFollowUp(unit); break;
        }
    }

}