

using Fire_Emblem;

class DragonWall : BaseSkill {
    public override string name { get; } = "Dragon Wall";

    public override BaseCondition condition { get; } = new OnGreaterPlayerStat(Stat.Res);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var unitStat = game.Fighter(player).Get(Stat.Res);
        var rivalStat = game.Fighter(player + 1).Get(Stat.Res);
        var percentage = 4 * (unitStat - rivalStat);

        yield return new Effect {
            percentDamageReduction = Math.Min(percentage, 40),
        };
    }
}