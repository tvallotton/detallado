

using Fire_Emblem;

class BrazenAtkDef : BaseSkill {
    public override string Name() {
        return "Brazen Atk/Def";
    }

    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.diff.Def = 10;
        effect.diff.Atk = 10;
        return effect;
    }

}