

using Fire_Emblem;

class SpdResPlus5 : BaseSkill {
    public override string name { get; } = "Spd/Res +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 5,
                Res = 5,
            }
        };
    }

}