
using Fire_Emblem;

public class OnWeaponAdvantage : BaseCondition {
    protected internal override bool Check(GameState game, int player) {
        var unit = game.GetFighter(player);
        var rival = game.GetFighter(1 + player);
        return unit.HasAdvantageOver(rival);
    }
}