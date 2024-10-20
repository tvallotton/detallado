

using Fire_Emblem;

class BracingBlow : BaseSkill {
    public override string Name { get; } = "Bracing Blow";


    public override bool Condition(Game game, int player) {
        return game.turn == player;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 6;
        effect.difference.Res = 6;
        return effect;
    }

}