

using Fire_Emblem;

class BlueSkies : BaseSkill {
    public override string name { get; } = "Blue Skies";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            absoluteDamageReduction = 5,
            extraDamage = 5
        };
    }

}