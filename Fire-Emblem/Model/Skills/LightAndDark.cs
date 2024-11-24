

using Fire_Emblem;

class LightAndDark : BaseSkill {
    public override string name { get; } = "Light and Dark";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        yield return new Effect {
            neutralizedPenalty = Stats<bool>.All(),
        };

    }

    public override IEnumerable<Effect> RivalEffects(GameState game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = -5,
                Spd = -5,
                Def = -5,
                Res = -5,
            },
            neutralizedBonus = Stats<bool>.All(),
        };
    }

}