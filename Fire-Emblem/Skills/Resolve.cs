

using Fire_Emblem;

class Resolve : BaseSkill {
    public override string Name { get; } = "Resolve";

    public override BaseCondition Condition() {
        return new OnPlayerLowHP(75);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = 7;
        effect.difference.Res = 7;
        return effect;
    }

}