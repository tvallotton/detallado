
using Fire_Emblem;

public class OnRivalsTurn : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return !game.IsPlayersTurn(player);
    }
}