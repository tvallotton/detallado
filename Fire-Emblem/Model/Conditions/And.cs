

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class All(params BaseCondition[] conditions) : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return conditions.All(cond => cond.Check(game, player));
    }

}