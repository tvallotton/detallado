

using Fire_Emblem;

class LullSpdDef : BaseSkill {
    public override string Name { get; } = "Lull Spd/Def";

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = -3;
        effect.difference.Spd = -3;
        effect.neutralized.bonus.Spd = true;
        effect.neutralized.bonus.Def = true;
        return effect;
    }

}