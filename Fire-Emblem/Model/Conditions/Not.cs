

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class Not : BaseCondition {
    private BaseCondition _first;

    public Not(BaseCondition first) {
        _first = first;

    }

    protected internal override bool Check(GameState game, int player) {
        return !_first.Check(game, player);
    }

}