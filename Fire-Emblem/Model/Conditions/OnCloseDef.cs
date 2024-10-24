
using Fire_Emblem;

public class OnCloseDef : BaseCondition {

    public override bool Check(Game game, int player) {
        Weapon[] weapons = { Weapon.Axe, Weapon.Lance, Weapon.Sword };
        var fighter = game.Fighter(player + 1);
        return !game.IsPlayersTurn(player) && weapons.Contains(fighter.GetWeapon());
    }

}
