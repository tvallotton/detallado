

using Fire_Emblem;

class StillWater : BaseSkill {
    public override string Name { get; } = "Still Water";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = 6;
        effect.difference.Res = 6;
        effect.difference.Def = -2;
        return effect;
    }

}