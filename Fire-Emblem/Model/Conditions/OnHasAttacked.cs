


public class OnHasAttacked(Subject subject) : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        var unit = game.GetFighter(player + (int)subject);
        var rival = game.GetFighter(player + (int)subject + 1);
        return (
            !rival.HasEffect(EffectName.CounterAttackNegation) ||
            unit.HasEffect(EffectName.CounterAttacKNegationBlocker)
        );

    }
}
