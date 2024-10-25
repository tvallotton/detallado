

using Fire_Emblem;

class SwordFocus : BaseSkill {
    public override string name { get; } = "Sword Focus";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = -10,
                Atk = 10,
            }
        };
    }

}