

using Fire_Emblem;

class LullDefRes : BaseSkill {
    public override string Name { get; } = "Lull Def/Res";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = -3;
        effect.difference.Res = -3;
        effect.neutralized.bonus.Def = true;
        effect.neutralized.bonus.Res = true;
        return effect;
    }

}