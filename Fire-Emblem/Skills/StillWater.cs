

using Fire_Emblem;

class StillWater : BaseSkill {
    public override string Name() {
        return "Still Water";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = 6;
        effect.difference.Res = 6;
        effect.difference.Def = -2;
        return effect;
    }

}