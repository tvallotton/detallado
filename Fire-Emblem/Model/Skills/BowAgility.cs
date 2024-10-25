

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string name { get; } = "Bow Agility";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Bow);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}