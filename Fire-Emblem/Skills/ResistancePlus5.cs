

using Fire_Emblem;

class ResistancePlus5 : BaseSkill {
    public override string Name { get; } = "Resistance +5";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Res = 5;
        return effect;
    }

}