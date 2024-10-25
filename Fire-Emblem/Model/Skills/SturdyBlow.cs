

using Fire_Emblem;

class SturdyBow : BaseSkill {
    public override string name { get; } = "Sturdy Blow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Def = 6,
            }
        };
    }

}