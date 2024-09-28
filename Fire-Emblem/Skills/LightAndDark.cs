

using Fire_Emblem;

class LightAndDark : BaseSkill {
    public override string Name() {
        return "Light and Dark";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralize.penalty = Values<bool>.All();
        return effect;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Atk = -5;
        effect.diff.Spd = -5;
        effect.diff.Def = -5;
        effect.diff.Res = -5;
        effect.neutralize.bonus = Values<bool>.All();
        return effect;
    }

}