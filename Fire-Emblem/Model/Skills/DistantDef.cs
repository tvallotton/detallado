

using Fire_Emblem;

class DistantDef : BaseSkill {
    public override string name { get; } = "Distant Def";

    public override BaseCondition condition { get; } = new OnDistantDef();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 8,
                Res = 8
            }
        };
    }
    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };

    }

}