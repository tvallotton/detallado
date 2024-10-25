

using Fire_Emblem;

class SpeedPlus5 : BaseSkill {
    public override string name { get; } = "Speed +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 5,
            }
        };
    }

}