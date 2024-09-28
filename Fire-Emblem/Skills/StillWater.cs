

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
        effect.diff.Atk = 6;
        effect.diff.Res = 6;
        effect.diff.Def = -2;
        return effect;
    }

}