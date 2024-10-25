
using Fire_Emblem;

public class OnRivalWeapon : BaseCondition {
    private Weapon _weapon;

    public OnRivalWeapon(Weapon weapon) {
        _weapon = weapon;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player + 1).GetWeapon() == _weapon;
    }
}
