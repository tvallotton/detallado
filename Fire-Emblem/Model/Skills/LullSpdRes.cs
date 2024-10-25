

using Fire_Emblem;

class LullSpdRes : BaseSkill {
    public override string name { get; } = "Lull Spd/Res";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
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