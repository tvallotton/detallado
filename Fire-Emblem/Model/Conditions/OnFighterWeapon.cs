
using Fire_Emblem;

public class OnPlayerWeapon : BaseCondition {
    private Weapon _weapon;

    public OnPlayerWeapon(Weapon weapon) {
        _weapon = weapon;
    }

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player).GetWeapon() == _weapon;
    }
}
