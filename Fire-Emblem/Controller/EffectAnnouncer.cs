using Fire_Emblem_View;

public class EffectAnnouncer(FireEmblemView _view, int player, GameState _gameState) {

    Unit unit = _gameState.GetFighter(player);

    public void AnnounceEffects() {
        Action<EffectType>[] announcements = [AnnounceStatEffects, AnnounceNeutralizedEffects];
        foreach (var func in announcements) {
            func(EffectType.Bonus);
            func(EffectType.Penalty);
        }
        AnnounceAllDamageEffects();
        AnnounceHealingEffects();
        AnnounceCounterAttackNegation();
    }

    private void AnnounceAllDamageEffects() {
        AnnounceExtraDamageEffects();
        AnnouncePercentDamageReduction();
        AnnounceAbsoluteDamageReductionEffects();

    }

    private void AnnounceCounterAttackNegation() {
        if (_gameState.IsPlayersTurn(player) && unit.HasCounterAttackNegation())
            _view.AnnounceCounterAttackNegation(_gameState.GetFighter(player + 1));
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
}