

using Fire_Emblem;

class BeorcsBlessing : BaseSkill {
    public override string name { get; } = "Beorc's Blessing";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };

    }

}