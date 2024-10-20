

using Fire_Emblem;

class FortDefRef : BaseSkill {
    public override string Name { get; } = "Fort. Def/Res";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = -2;
        effect.difference.Def = 6;
        effect.difference.Res = 6;
        return effect;
    }

}