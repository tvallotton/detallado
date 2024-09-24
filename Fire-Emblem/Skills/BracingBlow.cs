

using Fire_Emblem;

class BracingBlow : BaseSkill {
    public override string Name() {
        return "Bracing Blow";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Def+6\n"
            + $"{game.Fighter(player)} obtiene Res+6";
    }

    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Def = 6;
        effect.Res = 6;
        return effect;
    }

}