
using Fire_Emblem;

public class Always : BaseCondition {
    protected internal override bool Check(Game game, int player) {
        return true;
    }
}