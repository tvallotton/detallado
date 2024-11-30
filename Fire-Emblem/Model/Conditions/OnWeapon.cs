using Fire_Emblem;
public class OnWeapon(Subject subject, Weapon weapon) : BaseCondition {

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player + (int)subject).GetWeapon() == weapon;
    }
}