

using Fire_Emblem;

class AgneasArrow : BaseSkill {
    public override string Name { get; } = "Agnea's Arrow";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.penalty = Stats<bool>.All();
        return effect;
    }

}