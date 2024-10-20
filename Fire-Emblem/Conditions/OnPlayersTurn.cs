
using Fire_Emblem;

public class OnPayersTurnCondition: BaseCondition {
    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }
}