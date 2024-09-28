

using Fire_Emblem;

class BrazenAtkSpd : BaseSkill {
    public override string Name() {
        return "Brazen Atk/Spd";
    }


    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.diff.Spd = 10;
        effect.diff.Atk = 10;
        return effect;
    }

}