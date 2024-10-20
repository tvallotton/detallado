

using Fire_Emblem;

class BeorcsBlessing : BaseSkill {
    public override string Name { get; } = "Beorc's Blessing";



    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}