

using Fire_Emblem;

class SpdResPlus5 : BaseSkill {
    public override string Name() {
        return "Spd/Res +5";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Spd+5\n"
            + $"{game.Fighter(player)} obtiene Res+5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Res = 5;
        effect.Spd = 5;
        return effect;
    }

}