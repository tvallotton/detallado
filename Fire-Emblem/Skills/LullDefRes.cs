

using Fire_Emblem;

class LullDefRes : BaseSkill {
    public override string Name() {
        return "Lull Def/Res";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Def = -3;
        effect.diff.Res = -3;
        effect.neutralize.bonus.Def = true;
        effect.neutralize.bonus.Res = true;
        return effect;
    }

}