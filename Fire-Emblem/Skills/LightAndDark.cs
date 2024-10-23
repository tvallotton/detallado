

using Fire_Emblem;

class LightAndDark : BaseSkill {
    public override string Name { get; } = "Light and Dark";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            neutralizedPenalty = Stats<bool>.All(),
        };

    }

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = -5,
                Spd = -5,
                Def = -5
            },
            neutralizedBonus = Stats<bool>.All(),
        };
    }

}