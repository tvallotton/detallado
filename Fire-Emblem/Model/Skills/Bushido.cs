

using Fire_Emblem;

class Bushido : BaseSkill {
    public override string name { get; } = "Bushido";

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var unit = game.Fighter(player);
        var rival = game.Fighter(player);
        var difference = Math.Max(unit.Get(Stat.Spd) - rival.Get(Stat.Spd), 0);
        yield return new Effect {
            extraDamage = 7,
            percentDamageReduction = Math.Min(difference * 4, 40),
        };
    }
}