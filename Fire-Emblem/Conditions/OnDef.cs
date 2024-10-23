
using Fire_Emblem;

public class OnDef : BaseCondition {

    public override bool Check(Game game, int player) {
        Weapon[] weapons = { Weapon.Axe, Weapon.Lance, Weapon.Sword };
        var fighter = game.Fighter(player + 1);
        return game.turn != player && weapons.Contains(fighter.Weapon());
    }

}
