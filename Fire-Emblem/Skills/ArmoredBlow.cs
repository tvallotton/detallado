

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string Name() {
        return "Armored Blow";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Def+8";

    }

    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.isBonus = true;
        effect.Def = 8;
        return effect;
    }

}