

using Fire_Emblem;

class DeadlyBlade : BaseSkill {
    public override string Name { get; } = "Deadly Blade";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Sword);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 8,
                Spd = 8
            }
        };
    }
}