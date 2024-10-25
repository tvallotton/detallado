

using Fire_Emblem;

class CloseDef : BaseSkill {
    public override string name { get; } = "Close Def";

    public override BaseCondition condition { get; } = new OnCloseDef();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 8,
                Res = 8
            }
        };
    }

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };
    }

}