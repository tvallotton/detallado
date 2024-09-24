

using Fire_Emblem;

class BrazenSpdRes : BaseSkill {
    public override string Name() {
        return "Brazen Spd/Res";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Spd+10\n"
            + $"{game.Fighter(player)} obtiene Res+10";
    }

    public override bool Condition(Game game, int player) {
        Console.WriteLine(game.Fighter(player).PercentageHP());
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Res = 10;
        effect.Spd = 10;
        return effect;
    }

}