

using Fire_Emblem;

class SpeedPlus5 : BaseSkill {
    public override string name { get; } = "Speed +5";

    public override BaseCondition condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 5,
            }
        };
    }

}