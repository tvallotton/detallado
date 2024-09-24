

using Fire_Emblem;

class ResistancePlus5 : BaseSkill {
    public override string Name() {
        return "Resistance +5";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Res+5";

    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Res = 5;
        return effect;
    }

}