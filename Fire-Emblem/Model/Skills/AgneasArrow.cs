

using Fire_Emblem;

class AgneasArrow : BaseSkill {
    public override string Name { get; } = "Agnea's Arrow";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            neutralizedPenalty = Stats<bool>.All(),
        };
    }

}