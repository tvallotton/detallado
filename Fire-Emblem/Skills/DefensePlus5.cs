

using Fire_Emblem;

class DefensePlus5 : BaseSkill {
    public override string Name { get; } = "Defense +5";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 5;
        return effect;
    }

}