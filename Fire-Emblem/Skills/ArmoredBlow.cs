

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string Name() {
        return "Armored Blow";
    }

    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 8;
        return effect;
    }

}