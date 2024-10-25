

using Fire_Emblem;

class WardingBlow : BaseSkill {
    public override string name { get; } = "Warding Blow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = 8
            }
        };
    }

}