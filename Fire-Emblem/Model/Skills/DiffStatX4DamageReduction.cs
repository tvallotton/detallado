




using Fire_Emblem;

class DiffStatX4DamageReduction(string _name, Stat _stat, BaseCondition? _condition = null) : BaseSkill {

    public override string name { get; } = _name;

    public override BaseCondition condition { get; } = (
        _condition == null
        ? new OnGreaterPlayerStat(_stat)
        : _condition.And(new OnGreaterPlayerStat(_stat))
    );

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var unit = game.Fighter(player);
        var rival = game.Fighter(1 + player);
        var difference = Math.Max(unit.Get(_stat) - rival.Get(_stat), 0);
        yield return new Effect {
            percentDamageReduction = Math.Min(difference * 4, 40),
        };
    }

}