

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string Name { get; } = "Armored Blow";

    public override BaseCondition Condition() {
        return new OnPlayersTurn();
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 8;
        return effect;
    }

}