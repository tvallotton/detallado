

using Fire_Emblem;

class DistantDef : BaseSkill {
    public override string Name { get; } = "Distant Def";

    public override BaseCondition Condition() {
        return new OnDef();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = 8;
        effect.difference.Res = 8;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}