

using Fire_Emblem;

class FairFight : BaseSkill {
    public override string Name { get; } = "Fair Fight";

    public override BaseCondition Condition() {
        return new OnPlayersTurn();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 5;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 5;
        return effect;
    }

}