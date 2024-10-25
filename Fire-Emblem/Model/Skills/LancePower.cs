

using Fire_Emblem;

class LancePower : BaseSkill {
    public override string name { get; } = "Lance Power";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Lance);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}