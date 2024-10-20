

using Fire_Emblem;

class LullSpdRes : BaseSkill {
    public override string Name() {
        return "Lull Spd/Res";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = -3;
        effect.difference.Res = -3;
        effect.neutralized.bonus.Spd = true;
        effect.neutralized.bonus.Res = true;
        return effect;
    }

}