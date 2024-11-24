
using Fire_Emblem;

public class OnMaleRival : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player + 1).GetGender() == "Male";
    }
}