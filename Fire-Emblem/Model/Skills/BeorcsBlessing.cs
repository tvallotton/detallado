

using Fire_Emblem;

class BeorcsBlessing : BaseSkill {
    public override string name { get; } = "Beorc's Blessing";

    public override BaseCondition condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };

    }

}