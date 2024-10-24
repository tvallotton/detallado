

using Fire_Emblem;

class StillWater : BaseSkill {
    public override string Name { get; } = "Still Water";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Res = 6,
                Def = -2
            }
        };
    }

}