

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string Name { get; } = "Atk/Res +5";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Res = 5;
        effect.difference.Atk = 5;
        return effect;
    }

}