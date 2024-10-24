

using Fire_Emblem;

class SwordAgility : BaseSkill {
    public override string Name { get; } = "Sword Agility";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Sword);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}