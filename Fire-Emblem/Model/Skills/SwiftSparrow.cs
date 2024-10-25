

using Fire_Emblem;



class SwiftSparrow : BaseSkill {
    public override string name { get; } = "Swift Sparrow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Spd = 6,
            }
        };
    }

}