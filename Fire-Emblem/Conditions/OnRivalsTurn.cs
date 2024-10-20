
using Fire_Emblem;

public class OnRivalsTurnCondition: BaseCondition {
    public override bool Condition(Game game, int player) {
        return game.turn != player;
    }
}