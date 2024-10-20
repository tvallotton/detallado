

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
        effect.difference.Def = -3;
        effect.difference.Atk = -3;
        effect.neutralized.bonus.Def = true;
        effect.neutralized.bonus.Atk = true;
        return effect;
    }

}