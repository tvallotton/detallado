

using Fire_Emblem;

class AgneasArrow : BaseSkill {
    public override string Name() {
        return "Agnea's Arrow";
    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralize.penalty = Values<bool>.All();
        return effect;
    }

}