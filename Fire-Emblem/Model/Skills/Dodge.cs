

using Fire_Emblem;

class Dodge : BaseSkill {
    public override string name { get; } = "Dodge";

    public override BaseCondition condition { get; } = new OnGreaterPlayerStat(Stat.Spd);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var unitSpd = game.Fighter(player).Get(Stat.Spd);
        var rivalSpd = game.Fighter(player + 1).Get(Stat.Spd);
        var percentage = 4 * (unitSpd - rivalSpd);

        yield return new Effect {
            percentDamageReduction = Math.Min(percentage, 40),
        };
    }
}