

using Fire_Emblem;

class BracingBlow : BaseSkill {
    public override string Name() {
        return "Bracing Blow";
    }


    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.diff.Def = 6;
        effect.diff.Res = 6;
        return effect;
    }

}