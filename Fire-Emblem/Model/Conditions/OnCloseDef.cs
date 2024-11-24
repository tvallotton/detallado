
using Fire_Emblem;

public class OnCloseDef : BaseCondition {

    protected internal override bool Check(GameState game, int player) {
        Weapon[] weapons = { Weapon.Axe, Weapon.Lance, Weapon.Sword };
        var fighter = game.GetFighter(player + 1);
        return !game.IsPlayersTurn(player) && weapons.Contains(fighter.GetWeapon());
    }

}
