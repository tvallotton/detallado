
using Fire_Emblem;

public class OnGreaterPlayerStat : BaseCondition {
    private Stat _stat;
    private int _byHowMuch;

    public override EffectDependency dependency { get; } = EffectDependency.Stats;

    public OnGreaterPlayerStat(Stat stat, int byHowMuch = 0) {
        _stat = stat;
        _byHowMuch = byHowMuch;
    }

    protected internal override bool Check(GameState game, int player) {
        var unitStat = game.GetFighter(player).GetStat(_stat);
        var rivalStat = game.GetFighter(player + 1).GetStat(_stat);
        return unitStat > rivalStat + _byHowMuch;
    }
}
