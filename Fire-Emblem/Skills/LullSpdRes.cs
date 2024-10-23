

using Fire_Emblem;

class LullSpdRes : BaseSkill {
    public override string Name { get; } = "Lull Spd/Res";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = -3,
                Res = -3
            },
            neutralizedBonus = new Stats<bool> {
                Spd = true,
                Res = true
            }
        };
    }

}