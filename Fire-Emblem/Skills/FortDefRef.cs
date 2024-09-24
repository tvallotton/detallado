

using Fire_Emblem;

class FortDefRef : BaseSkill {
    public override string Name() {
        return "Fort. Def/Res";
    }

    public override string? Anounce(Game game, int player) {
        return
         $"{game.Fighter(player)} obtiene Def+6\n"
        + $"{game.Fighter(player)} obtiene Res+6\n"
        + $"{game.Fighter(player)} obtiene Atk-2";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.Atk = -2;
        effect.Def = 6;
        effect.Res = 6;
        return effect;
    }

}