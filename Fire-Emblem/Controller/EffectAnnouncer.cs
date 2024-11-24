using Fire_Emblem_View;

public class EffectAnnouncer(FireEmblemView _view, Unit fighter) {

    public void AnnounceEffects() {
        Action<EffectType>[] announcements = [AnnounceStatEffects, AnnounceNeutralizedEffects];
        foreach (var func in announcements) {
            func(EffectType.Bonus);
            func(EffectType.Penalty);
        }
        AnnounceAllDamageEffects();
        AnnounceHealingEffects();

    }

    private void AnnounceAllDamageEffects() {
        AnnounceExtraDamageEffects();
        AnnouncePercentDamageReduction();
        AnnounceAbsoluteDamageReductionEffects();
    }

    private void AnnounceHealingEffects() {
        _view.AnnounceHealingEffect(fighter, fighter.GetTotalHealingEffect());
    }

    private void AnnouncePercentDamageReduction() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetTotalPercentDamageReduction(scope);
            _view.AnnouncePercentEffect(fighter, reduction, scope);
        }
    }
    private void AnnounceExtraDamageEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var damage = fighter.GetExtraDamage(scope);
            _view.AnnounceExtraDamageEffect(fighter, damage, scope);
        }
    }

    private void AnnounceAbsoluteDamageReductionEffects() {
        foreach (var scope in Enum.GetValues<Scope>()) {
            var reduction = fighter.GetAbsoluteDamageReduction(scope);
            _view.AnnounceAbsoluteDamageReduction(fighter, reduction, scope);
        }
    }

    private void AnnounceStatEffects(EffectType effectType) {

        foreach (var scope in Enum.GetValues<Scope>()) {
            AnnounceStatEffectsForScope(fighter, effectType, scope);
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
            if (fighter.IsNeutralized(stat, effectType))
                _view.AnnounceNeutralizedEffect(fighter, stat, effectType);
        }
    }
}