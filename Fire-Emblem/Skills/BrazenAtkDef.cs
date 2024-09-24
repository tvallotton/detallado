

using Fire_Emblem;

class BrazenAtkDef : BaseSkill {
    public override string Name() {
        return "Brazen Atk/Def";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Atk+10\n"
            + $"{game.Fighter(player)} obtiene Def+10";
    }

    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Def = 10;
        effect.Atk = 10;
        return effect;
    }

}