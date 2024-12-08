

using System.Runtime.ExceptionServices;
using Fire_Emblem;

public class Any(params BaseCondition[] conditions) : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return conditions.Any((cond) => cond.Check(game, player));
    }

}