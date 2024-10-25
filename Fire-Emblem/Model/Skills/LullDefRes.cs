

using Fire_Emblem;

class LullDefRes : BaseSkill {
    public override string name { get; } = "Lull Def/Res";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = -3,
                Res = -3,
            },
            neutralizedBonus = new Stats<bool> {
                Def = true,
                Res = true,
            }
        };
    }

}