

using Fire_Emblem;

class DeadlyBlade : BaseSkill {
    public override string name { get; } = "Deadly Blade";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 8,
                Spd = 8
            }
        };
    }
}