

using Fire_Emblem;

class DistantDef : BaseSkill {
    public override string Name { get; } = "Distant Def";

    public override BaseCondition Condition { get; } = new OnDistantDef();

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