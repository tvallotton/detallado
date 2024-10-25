

using Fire_Emblem;

class SingleMinded : BaseSkill {
    public override string name { get; } = "Single-Minded";

    public override BaseCondition condition { get; } = new OnRivalIsLatestOpponent();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 8,
            }
        };

    }

}