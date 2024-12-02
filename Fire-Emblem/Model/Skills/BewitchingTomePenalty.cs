

using Fire_Emblem;

// Bewitching Tome's penalty  depends on its own bonus, so they must be written as separate classes 
// so they can be evaluated at different stages.

class BewitchingTomePenalty : BaseSkill {
    public override string name { get; } = "Bewitching Tome";



    public override BaseCondition condition { get; } = (
        new OnTurn(Subject.Self)
            .Or(new OnWeapon(Subject.Rival, Weapon.Bow))
            .Or(new OnWeapon(Subject.Rival, Weapon.Magic))
            .DependsOn(EffectDependency.StatsAndModifiesStats)
    );

    public override IEnumerable<Effect> RivalEffects(GameState game, int player) {
        var unit = game.GetFighter(player);
        var rival = game.GetFighter(player + 1);
        int x;
        if (unit.HasAdvantageOver(rival) || unit.GetStat(Stat.Spd) > rival.GetStat(Stat.Spd))
            x = 40;
        else
            x = 20;
        Console.WriteLine($"{rival} {x} {rival.GetBaseStat(Stat.Atk)} {rival.GetStat(Stat.Atk)} ");
        yield return new Effect {
            damageBeforeCombat = x * rival.GetStat(Stat.Atk) / 100,
        };
    }
}