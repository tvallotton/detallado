

using Fire_Emblem;

class SpdResPlus5 : BaseSkill {
    public override string Name { get; } = "Spd/Res +5";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 5,
                Res = 5,
            }
        };
    }

}