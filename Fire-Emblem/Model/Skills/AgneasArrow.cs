

using Fire_Emblem;

class AgneasArrow : BaseSkill {
    public override string name { get; } = "Agnea's Arrow";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            neutralizedPenalty = Stats<bool>.All(),
        };
    }

}