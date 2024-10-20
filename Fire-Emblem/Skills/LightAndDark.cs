

using Fire_Emblem;

class LightAndDark : BaseSkill {
    public override string Name { get; } = "Light and Dark";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.penalty = Stats<bool>.All();
        return effect;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = -5;
        effect.difference.Spd = -5;
        effect.difference.Def = -5;
        effect.difference.Res = -5;
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}