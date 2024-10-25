

using Fire_Emblem;

class LullAtkRes : BaseSkill {
    public override string name { get; } = "Lull Atk/Res";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = -3,
                Atk = -3
            },
            neutralizedBonus = new Stats<bool> {
                Res = true,
                Atk = true
            }
        };
    }

}