
using Fire_Emblem;

public class OnFighterWeapon: BaseCondition {
    private Weapon _weapon;

    public OnFighterWeapon(Weapon weapon) {
        _weapon = _weapon;
    }

    public override bool Condition(Game game, int player) {
         return game.Fighter(player).Weapon() == _weapon;
    }
}
