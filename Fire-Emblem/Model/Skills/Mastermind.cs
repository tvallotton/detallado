

using System.Security.Cryptography.X509Certificates;
using Fire_Emblem;

class Mastermind : BaseSkill {
    public override string name { get; } = "Mastermind";

    public override BaseCondition condition { get; } = new OnTurn(Subject.Self).DependsOn(EffectDependency.Stats);



    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        var unit = game.GetFighter(player);
        var X = (9 + unit.CountEffects(EffectType.Bonus)) * 8 / 10;
        var Y = (9 + unit.CountEffects(EffectType.Penalty)) * 8 / 10;
        Console.WriteLine($"DEBUG: {X + Y}");
        yield return new Effect {
            difference = new Stats<int> { Atk = 9, Spd = 9 },
            extraDamage = X + Y,
        };
    }
}