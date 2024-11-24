

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class And : BaseCondition {
    private BaseCondition _first;
    private BaseCondition _second;
    public And(BaseCondition first, BaseCondition second) {
        _first = first;
        _second = second;
    }

    protected internal override bool Check(GameState game, int player) {
        return _first.Check(game, player) && _second.Check(game, player);
    }

}