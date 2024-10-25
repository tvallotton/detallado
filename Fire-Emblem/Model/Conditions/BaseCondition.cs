

using System.ComponentModel.Design;
using Fire_Emblem;

public abstract class BaseCondition {
    public virtual EffectDependency dependency { get; } = EffectDependency.None;

    protected internal abstract bool Check(Game game, int player);

    public bool Holds(Game game, int player, EffectDependency dependencies) {
        return dependencies == dependency && Check(game, player);
    }

    public BaseCondition And(BaseCondition condition) {
        return new And(this, condition);
    }

    public BaseCondition Or(BaseCondition condition) {
        return new And(this, condition);
    }
    public BaseCondition Not() {
        return new Not(this);
    }

}

