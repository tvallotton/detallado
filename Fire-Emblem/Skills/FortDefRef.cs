

using Fire_Emblem;

class FortDefRef : BaseSkill {
    public override string Name() {
        return "Fort. Def/Res";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Atk = -2;
        effect.diff.Def = 6;
        effect.diff.Res = 6;
        return effect;
    }

}