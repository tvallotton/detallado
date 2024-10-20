

using Fire_Emblem;

class LullSpdRes : BaseSkill {
    public override string Name { get; } = "Lull Spd/Res";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = -3;
        effect.difference.Res = -3;
        effect.neutralized.bonus.Spd = true;
        effect.neutralized.bonus.Res = true;
        return effect;
    }

}