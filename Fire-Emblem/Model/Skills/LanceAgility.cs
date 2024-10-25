

using Fire_Emblem;

class LanceAgility : BaseSkill {
    public override string name { get; } = "Lance Agility";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Lance);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 12,
                Atk = -6
            }
        };
    }

}