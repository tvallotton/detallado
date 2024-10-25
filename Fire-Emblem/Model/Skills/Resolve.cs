

using Fire_Emblem;

class Resolve : BaseSkill {
    public override string name { get; } = "Resolve";

    public override BaseCondition condition { get; } = new OnPlayerLowHP(75);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 7,
                Res = 7,
            }
        };

    }

}