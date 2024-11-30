


public class OnHasAttacked(Subject subject) : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        var fighter = game.GetFighter(player + (int)subject);
        return fighter.HasAttackedThisRound();
    }
}
