

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string Name { get; } = "Bow Agility";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Bow);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}