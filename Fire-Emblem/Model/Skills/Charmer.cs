

using Fire_Emblem;

class Charmer : BaseSkill {
    public override string name { get; } = "Charmer";

    public override BaseCondition condition { get; } = new OnRivalIsLatestOpponent();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = -3,
                Spd = -3,
            }
        };
    }

}