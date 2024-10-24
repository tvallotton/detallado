

using Fire_Emblem;

class SturdyBow : BaseSkill {
    public override string Name { get; } = "Sturdy Blow";

    public override BaseCondition Condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Def = 6,
            }
        };
    }

}