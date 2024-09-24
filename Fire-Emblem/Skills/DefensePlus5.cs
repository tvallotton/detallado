

using Fire_Emblem;

class DefensePlus5 : BaseSkill {
    public override string Name() {
        return "Defense +5";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Def+5";

    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Def = 5;
        return effect;
    }

}