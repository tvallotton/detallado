
using Fire_Emblem;

public class OnDependency(BaseCondition condition, EffectDependency _dependency) : BaseCondition {
    public override EffectDependency dependency { get; } = _dependency;

    protected internal override bool Check(GameState game, int player) {
        return condition.Check(game, player);
    }
}