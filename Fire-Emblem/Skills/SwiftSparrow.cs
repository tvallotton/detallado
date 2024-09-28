

using Fire_Emblem;

class SwiftSparrow : BaseSkill {
    public override string Name() {
        return "Swift Sparrow";
    }

    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Atk = 6;
        effect.diff.Spd = 6;
        return effect;
    }

}