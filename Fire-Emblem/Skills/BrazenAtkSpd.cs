

using Fire_Emblem;

class BrazenAtkSpd : BaseSkill {
    public override string Name { get; } = "Brazen Atk/Spd";


    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Spd = 10;
        effect.difference.Atk = 10;
        return effect;
    }

}