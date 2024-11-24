
using Fire_Emblem;

public class OnGreaterPlayerStat : BaseCondition {
    private Stat _stat;

    public override EffectDependency dependency { get; } = EffectDependency.Stats;

    public OnGreaterPlayerStat(Stat stat) {
        _stat = stat;
    }

    protected internal override bool Check(GameState game, int player) {
        var unitStat = game.GetFighter(player).Get(_stat);
        var rivalStat = game.GetFighter(player + 1).Get(_stat);
        return unitStat > rivalStat;
    }
}
