

using Fire_Emblem;

class LanceAgility : BaseSkill {
    public override string Name { get; } = "Lance Agility";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Lance);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}