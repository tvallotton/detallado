

using Fire_Emblem;

class AttackPlus6 : BaseSkill {
    public override string Name { get; } = "Attack +6";


    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 6;
        return effect;
    }

}