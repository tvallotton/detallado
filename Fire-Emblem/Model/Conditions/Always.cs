
using Fire_Emblem;

public class Always : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return true;
    }
}