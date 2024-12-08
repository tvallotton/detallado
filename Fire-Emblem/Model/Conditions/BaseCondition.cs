

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Fire_Emblem;

public abstract class BaseCondition {
    public virtual EffectDependency dependency { get; } = EffectDependency.None;

    protected internal abstract bool Check(GameState game, int player);

    public bool Holds(GameState game, int player, EffectDependency dependencies) {
        return dependencies == dependency && Check(game, player);
    }

    public BaseCondition And(BaseCondition condition) {
        return new All(this, condition);
    }

    public BaseCondition Or(BaseCondition condition) {
        return new Any(this, condition);
    }
    public BaseCondition Not() {
        return new Not(this);
    }

    public BaseCondition DependsOn(EffectDependency dependency) {
        return new OnDependency(this, dependency);
    }

}

