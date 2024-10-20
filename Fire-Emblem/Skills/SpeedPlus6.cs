

using Fire_Emblem;

class SpeedPlus5 : BaseSkill {
    public override string Name() {
        return "Speed +5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 5;
        return effect;
    }

}