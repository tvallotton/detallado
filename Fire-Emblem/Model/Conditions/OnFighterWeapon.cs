
using Fire_Emblem;

public class OnFighterWeapon : BaseCondition {
    private Weapon _weapon;

    public OnFighterWeapon(Weapon weapon) {
        _weapon = weapon;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).GetWeapon() == _weapon;
    }
}
