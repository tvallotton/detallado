
using Fire_Emblem;

public class Never : BaseCondition {
    public override bool Check(Game game, int player) {
        return false;
    }
}