

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class And : BaseCondition {
    private BaseCondition _first;
    private BaseCondition _second;
    public And(BaseCondition first, BaseCondition second) {
        _first = first;
        _second = second;
    }

    public override bool Condition(Game game, int player) {
        return _first.Condition(game, player) && _second.Condition(game, player);
    }

}