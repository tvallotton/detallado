using Fire_Emblem_View;

public class EffectAnnouncer(View _view, Unit fighter) {

    public void AnnounceEffectsForPlayer() {
        Action<EffectType>[] announcements = [AnnounceStatEffectsForPlayer, AnnounceNeutralizedEffectsForPlayer];
        foreach (var func in announcements) {
            func(EffectType.Bonus);
            func(EffectType.Penalty);
        }
        AnnounceDamageEffectsForPlayer();

    }

    private void AnnounceDamageEffectsForPlayer() {
        AnnounceExtraDamageEffects();
        AnnouncePercentDamageReduction();
        AnnounceAbsoluteDamageReductionEffects();
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

    private void AnnounceStatEffectsForPlayer(EffectType effectType) {

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

    private void AnnounceNeutralizedEffectsForPlayer(EffectType effectType) {
        foreach (var stat in StatConstants.ORDERED) {
            if (fighter.IsNeutralized(stat, effectType))
                _view.AnnounceNeutralizedEffect(fighter, stat, effectType);
        }
    }
}