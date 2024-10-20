

using Fire_Emblem;

class AktDefPlus5 : BaseSkill {
    public override string Name() {
        return "Atk/Def +5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 5;
        effect.difference.Atk = 5;
        return effect;
    }

}