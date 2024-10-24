
using Fire_Emblem;

public class OnFighterWeapon : BaseCondition {
    private Weapon _weapon;

    public OnFighterWeapon(Weapon weapon) {
        _weapon = weapon;
    }

    public override bool Check(Game game, int player) {
        return game.Fighter(player).GetWeapon() == _weapon;
    }
}
