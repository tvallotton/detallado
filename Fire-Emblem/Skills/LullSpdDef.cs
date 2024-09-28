

using Fire_Emblem;

class LullSpdDef : BaseSkill {
    public override string Name() {
        return "Lull Spd/Def";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Def = -3;
        effect.diff.Spd = -3;
        effect.neutralize.bonus.Spd = true;
        effect.neutralize.penalty.Def = true;
        return effect;
    }

}