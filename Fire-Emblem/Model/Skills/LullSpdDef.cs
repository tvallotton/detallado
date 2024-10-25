

using Fire_Emblem;

class LullSpdDef : BaseSkill {
    public override string name { get; } = "Lull Spd/Def";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
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