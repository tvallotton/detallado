

using Fire_Emblem;

class LullAtkDef : BaseSkill {
    public override string Name { get; } = "Lull Atk/Def";

    public override BaseCondition Condition() {
        return new Always();
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