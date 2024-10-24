
using Fire_Emblem;

public class OnDistantDef : BaseCondition {

    public override bool Check(Game game, int player) {
        Weapon[] weapons = { Weapon.Magic, Weapon.Bow };
        var fighter = game.Fighter(player + 1);
        return !game.IsPlayersTurn(player) && weapons.Contains(fighter.GetWeapon());
    }

}
