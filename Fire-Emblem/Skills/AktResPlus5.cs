

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string Name { get; } = "Atk/Res +5";

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Res = 5;
        effect.difference.Atk = 5;
        return effect;
    }

}