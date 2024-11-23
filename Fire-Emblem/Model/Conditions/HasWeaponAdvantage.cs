
using Fire_Emblem;

public class OnWeaponAdvantage : BaseCondition {
    protected internal override bool Check(Game game, int player) {
        var unit = game.Fighter(player);
        var rival = game.Fighter(1 + player);
        return unit.HasAdvantageOver(rival);
    }
}