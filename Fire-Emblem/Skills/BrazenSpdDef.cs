

using Fire_Emblem;

class BrazenSpdDef : BaseSkill {
    public override string Name() {
        return "Brazen Spd/Def";
    }


    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 10;
        effect.difference.Spd = 10;
        return effect;
    }

}