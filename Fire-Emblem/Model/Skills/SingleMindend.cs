

using Fire_Emblem;

class SingleMinded : BaseSkill {
    public override string name { get; } = "Single-Minded";

    public override BaseCondition condition { get; } = new OnRivalIsLatestOpponent();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 8,
            }
        };

    }

}