
using Fire_Emblem;

public class Never : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return false;
    }
}