

using Fire_Emblem;

class CloseDef : BaseSkill {
    public override string name { get; } = "Close Def";

    public override BaseCondition condition { get; } = new OnCloseDef();

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 8,
                Res = 8
            }
        };
    }

    public override IEnumerable<Effect> RivalEffects(GameState game, int player) {
        yield return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };
    }

}