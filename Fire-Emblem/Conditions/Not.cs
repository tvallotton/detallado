

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class Not : BaseCondition {
    private BaseCondition _first;

    public Not(BaseCondition first) {
        _first = first;

    }

    public override bool Condition(Game game, int player) {
        return !_first.Condition(game, player);
    }

}