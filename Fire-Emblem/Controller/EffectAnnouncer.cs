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
        AnnounceBeforeCombatDamage();
        AnnounceHealingEffects();
        AnnounceCounterAttackNegation();
        AnnounceCounterAttackNegationBlocker();
    }

    public void AnnouncePostFightEffects() {
        AnnounceAfterCombatDamage();
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


    private void AnnounceCounterAttackNegationBlocker() {
        var isPlayersTurn = _gameState.IsPlayersTurn(player);
        var rivalHasCounterAttackNegation = rival.HasEffect(EffectName.CounterAttackNegation);
        var hasCounterAttackNegationBlocker = unit.HasEffect(EffectName.CounterAttacKNegationBlocker);
        if (!isPlayersTurn && rivalHasCounterAttackNegation && hasCounterAttackNegationBlocker)
            _view.AnnounceCounterAttackNegationBlocker(unit);

    }

    private void AnnounceHealingEffects() {
        _view.AnnounceHealingEffect(unit, unit.GetTotalHealingEffect());
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
    private void AnnounceBeforeCombatDamage() {
        if (unit.HasEffect(EffectName.DamageBeforeCombat)) {
            int damage = unit.SumEffects(EffectName.DamageBeforeCombat);
            unit.TakeDamage(damage);
            _view.AnnounceBeforeCombatDamage(unit, damage, unit.GetHP());
        }
    }

    private void AnnounceAfterCombatDamage() {
        if (!unit.HasEffect(EffectName.DamageAfterCombat)) {
            return;
        }
        int rawDamage = unit.SumEffects(EffectName.DamageAfterCombat);

        int actualDamage = Math.Min(rawDamage, unit.GetHP() - 1);

        if (unit.IsAlive()) {
            unit.TakeDamage(actualDamage);
            _view.AnnounceAfterCombatDamage(unit, rawDamage);
        }
    }
}