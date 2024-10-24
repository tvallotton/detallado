
using Fire_Emblem;

public class OnPlayersTurn : BaseCondition {
    public override bool Check(Game game, int player) {
        return game.IsPlayersTurn(player);
    }
}