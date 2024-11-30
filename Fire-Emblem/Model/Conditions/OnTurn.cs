
using Fire_Emblem;

public class OnTurn(Subject subject) : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        return game.IsPlayersTurn(player +(int)subject);
    }
}