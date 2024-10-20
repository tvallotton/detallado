

using Fire_Emblem;

class BeorcsBlessing : BaseSkill {
    public override string Name { get; } = "Beorc's Blessing";



    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}