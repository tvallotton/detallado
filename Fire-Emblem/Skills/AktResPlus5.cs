

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string Name() {
        return "Atk/Res +5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.diff.Res = 5;
        effect.diff.Atk = 5;
        return effect;
    }

}