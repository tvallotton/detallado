

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
        effect.difference.Spd = -3;
        effect.difference.Atk = -3;
        effect.neutralized.bonus.Spd = true;
        effect.neutralized.bonus.Atk = true;
        return effect;
    }

}