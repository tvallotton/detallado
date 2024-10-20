

using Fire_Emblem;

class FairFight : BaseSkill {
    public override string Name() {
        return "Fair Fight";
    }

    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 5;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 5;
        return effect;
    }

}