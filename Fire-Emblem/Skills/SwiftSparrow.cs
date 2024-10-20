

using Fire_Emblem;

class SwiftSparrow : BaseSkill {
    public override string Name { get; } = "Swift Sparrow";

    public override BaseCondition Condition() {
        return new OnPlayersTurn();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = 6;
        effect.difference.Spd = 6;
        return effect;
    }

}