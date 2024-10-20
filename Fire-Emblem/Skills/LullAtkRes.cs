

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
        effect.difference.Res = -3;
        effect.difference.Atk = -3;
        effect.neutralized.bonus.Res = true;
        effect.neutralized.bonus.Atk = true;
        return effect;
    }

}