

using Fire_Emblem;

class DefensePlus5 : BaseSkill {
    public override string Name() {
        return "Defense +5";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.diff.Def = 5;
        return effect;
    }

}