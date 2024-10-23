

using Fire_Emblem;

class CloseDef : BaseSkill {
    public override string Name { get; } = "Close Def";

    public override BaseCondition Condition { get; } = new OnDef();

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