
using Fire_Emblem;

public class OnGreaterPlayerStat : BaseCondition {
    private Stat _stat;

    public override EffectDependency dependency { get; } = EffectDependency.Stats;

    public OnGreaterPlayerStat(Stat stat) {
        _stat = stat;
    }

    protected internal override bool Check(Game game, int player) {
        var unitStat = game.Fighter(player).Get(_stat);
        var rivalStat = game.Fighter(player + 1).Get(_stat);
        return unitStat > rivalStat;
    }
}
