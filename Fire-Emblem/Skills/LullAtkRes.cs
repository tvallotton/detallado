

using Fire_Emblem;

class LullAtkRes : BaseSkill {
    public override string Name() {
        return "Lull Atk/Res";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Res = -3;
        effect.diff.Atk = -3;
        effect.neutralize.bonus.Res = true;
        effect.neutralize.bonus.Atk = true;
        return effect;
    }

}