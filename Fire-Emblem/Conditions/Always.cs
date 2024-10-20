
using Fire_Emblem;

public class AlwaysCondition: BaseCondition {
    public override bool Condition(Game game, int player) {
        return true;
    }
}