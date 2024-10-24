

using Fire_Emblem;

class EarthBoost : BaseSkill {
    public override string Name { get; } = "Earth Boost";

    public override BaseCondition Condition { get; } = new OnHigherPlayerHP(byHowMuch: 3);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 6,
            }
        };
    }

}