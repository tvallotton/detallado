

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
        effect.difference.Def = -3;
        effect.difference.Res = -3;
        effect.neutralized.bonus.Def = true;
        effect.neutralized.bonus.Res = true;
        return effect;
    }

}