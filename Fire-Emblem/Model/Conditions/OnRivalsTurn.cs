
using Fire_Emblem;

public class OnRivalsTurn : BaseCondition {
    public override bool Check(Game game, int player) {
        return !game.IsPlayersTurn(player);
    }
}