

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string name { get; } = "Bow Agility";

    public override BaseCondition condition { get; } = new OnFighterWeapon(Weapon.Bow);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}