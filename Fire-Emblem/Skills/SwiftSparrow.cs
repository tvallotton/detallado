

using Fire_Emblem;



class SwiftSparrow : BaseSkill {
    public override string Name { get; } = "Swift Sparrow";

    public override BaseCondition Condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Spd = 6,
            }
        };
    }

}