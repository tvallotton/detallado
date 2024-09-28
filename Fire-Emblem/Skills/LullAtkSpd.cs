

using Fire_Emblem;

class LullAtkSpd : BaseSkill {
    public override string Name() {
        return "Lull Atk/Spd";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Spd = -3;
        effect.diff.Atk = -3;
        effect.neutralize.bonus.Spd = true;
        effect.neutralize.bonus.Atk = true;
        return effect;
    }

}