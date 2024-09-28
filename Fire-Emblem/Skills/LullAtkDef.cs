

using Fire_Emblem;

class LullAtkDef : BaseSkill {
    public override string Name() {
        return "Lull Atk/Def";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Def = -3;
        effect.diff.Atk = -3;
        effect.neutralize.bonus.Def = true;
        effect.neutralize.bonus.Atk = true;
        return effect;
    }

}