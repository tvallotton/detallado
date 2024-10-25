
using Fire_Emblem;

public class OnPlayerWeapon : BaseCondition {
    private Weapon _weapon;

    public OnPlayerWeapon(Weapon weapon) {
        _weapon = weapon;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).GetWeapon() == _weapon;
    }
}
