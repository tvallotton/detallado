
using Fire_Emblem;

public class OnDistantDef : BaseCondition {

    protected internal override bool Check(GameState game, int player) {
        Weapon[] weapons = { Weapon.Magic, Weapon.Bow };
        var fighter = game.GetFighter(player + 1);
        return !game.IsPlayersTurn(player) && weapons.Contains(fighter.GetWeapon());
    }

}
