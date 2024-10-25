

using Fire_Emblem;

class Dodge : BaseSkill {
    public override string name { get; } = "Dodge";

    public override BaseCondition condition { get; } = new OnGreaterPlayerStat(Stat.Spd);

    public override Effect PlayerEffect(Game game, int player) {
        var unitSpd = game.Fighter(player).Get(Stat.Spd);
        var rivalSpd = game.Fighter(player).Get(Stat.Spd);
        var percentage = unitSpd - rivalSpd;
        return new Effect {
            percentDamageReduction = Math.Min(percentage, 40),
        };
    }
    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };

    }

}