
using Fire_Emblem;

public class OnPlayersTurn : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return game.IsPlayersTurn(player);
    }
}