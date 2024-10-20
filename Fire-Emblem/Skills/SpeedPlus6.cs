

using Fire_Emblem;

class SpeedPlus5 : BaseSkill {
    public override string Name { get; } = "Speed +5";

    public override BaseCondition Condition() {
        return new Always();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 5;
        return effect;
    }

}