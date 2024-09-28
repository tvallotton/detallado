

using Fire_Emblem;

class LifeAndDeath : BaseSkill {
    public override string Name() {
        return "Life and Death";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Atk = 6;
        effect.diff.Spd = 6;
        effect.diff.Def = -5;
        effect.diff.Res = -5;
        return effect;
    }

}