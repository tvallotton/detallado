
using Fire_Emblem;

public class OnMaleRival : BaseCondition {
    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player + 1).GetGender() == "Male";
    }
}