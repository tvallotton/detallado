

using Fire_Emblem;

class LullSpdDef : BaseSkill {
    public override string Name { get; } = "Lull Spd/Def";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -3,
                Spd = -3
            },
            neutralizedBonus = new Stats<bool> {
                Spd = true,
                Def = true
            }
        };
    }

}