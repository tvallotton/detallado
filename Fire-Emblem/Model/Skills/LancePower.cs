

using Fire_Emblem;

class LancePower : BaseSkill {
    public override string name { get; } = "Lance Power";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Lance);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}