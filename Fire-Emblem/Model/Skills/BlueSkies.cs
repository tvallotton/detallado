

using System.Diagnostics;
using Fire_Emblem;

class BlueSkies : BaseSkill {
    public override string name { get; } = "Blue Skies";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var effect = new Effect {
            name = "blue skies",
            absoluteDamageReduction = 5,
            extraDamage = 5
        };
        Trace.Assert(effect.absoluteDamageReduction == 5);
        yield return effect;
    }

}