

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
        effect.difference.Atk = 6;
        effect.difference.Spd = 6;
        effect.difference.Def = -5;
        effect.difference.Res = -5;
        return effect;
    }

}