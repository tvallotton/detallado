
using Fire_Emblem;

public class OnRivalIsLatestOpponent : BaseCondition {
    protected internal override bool Check(Game game, int player) {
        var opponent = game.Fighter(player + 1);
        return game.Fighter(player).IsLatestOpponent(opponent);
    }
}