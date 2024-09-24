

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string Name() {
        return "Atk/Res +5";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Atk+5\n"
            + $"{game.Fighter(player)} obtiene Res+5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Res = 5;
        effect.Atk = 5;
        return effect;
    }

}