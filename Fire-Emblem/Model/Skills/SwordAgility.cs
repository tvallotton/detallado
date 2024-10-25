

using Fire_Emblem;

class SwordAgility : BaseSkill {
    public override string name { get; } = "Sword Agility";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}