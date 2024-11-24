using Fire_Emblem_View;

public class EffectAnnouncer(View _view, Unit fighter) {

    public void AnounceEffectsForPlayer() {
        Action<EffectType>[] anouncements = [AnounceStatEffectsForPlayer, AnounceNeutralizedEffectsForPlayer];
        foreach (var func in anouncements) {
            func(EffectType.Bonus);
            func(EffectType.Penalty);
        }
        AnounceDamageEffectsForPlayer();

    }

    private void AnounceDamageEffectsForPlayer() {
        AnounceExtraDamageEffects();
        AnouncePercentDamageReduction();
        AnounceAbsoluteDamageReductionEffects();
    }


    private void AnouncePercentDamageReduction() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetTotalPercentDamageReduction(scope);
            _view.AnouncePercentEffect(fighter, reduction, scope);
        }
    }
    private void AnounceExtraDamageEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var damage = fighter.GetExtraDamage(scope);
            _view.AnounceExtraDamageEffect(fighter, damage, scope);
        }
    }

    private void AnounceAbsoluteDamageReductionEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetAbsoluteDamageReduction(scope);
            _view.AnounceAbsoluteDamageReduction(fighter, reduction, scope);
        }
    }

    private void AnounceStatEffectsForPlayer(EffectType effectType) {

        foreach (var scope in Enum.GetValues<Scope>()) {
            AnounceStatEffectsForScope(fighter, effectType, scope);
        }
    }
    private void AnounceStatEffectsForScope(Unit unit, EffectType effectType, Scope scope) {
        foreach (var stat in StatConstants.ORDERED) {
            var value = unit.GetEffectFor(stat, effectType, (effect) => effect.scope == scope);
            switch (scope) {
                case Scope.ALL: _view.AnounceStatEffect(unit, stat, value); break;
                case Scope.FIRST_ATTACK: _view.AnounceStatEffectFirstAttack(unit, stat, value); break;
                case Scope.FOLLOW_UP: _view.AnounceStatEffectFollowUp(unit, stat, value); break;
            };
        }
    }

    private void AnounceNeutralizedEffectsForPlayer(EffectType effectType) {
        foreach (var stat in StatConstants.ORDERED) {
            if (fighter.IsNeutralized(stat, effectType))
                _view.AnounceNeutralizedEffect(fighter, stat, effectType);
        }
    }
}