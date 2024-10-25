

using Fire_Emblem;

class WardingBlow : BaseSkill {
    public override string name { get; } = "Warding Blow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = 8
            }
        };
    }

}