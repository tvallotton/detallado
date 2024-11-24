
using Fire_Emblem;

public class OnRivalIsLatestOpponent : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        var opponent = game.GetFighter(player + 1);
        return game.GetFighter(player).IsLatestOpponent(opponent);
    }
}