
using Fire_Emblem;

public class Never : BaseCondition {
    protected internal override bool Check(Game game, int player) {
        return false;
    }
}