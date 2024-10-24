

using Fire_Emblem;

class Charmer : BaseSkill {
    public override string Name { get; } = "Charmer";

    public override BaseCondition Condition { get; } = new OnRivalIsLatestOpponent();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = -3,
                Spd = -3,
            }
        };
    }

}