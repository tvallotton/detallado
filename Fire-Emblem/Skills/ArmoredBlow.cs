

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string Name { get; } = "Armored Blow";

    public override BaseCondition Condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 8
            }
        };
    }

}