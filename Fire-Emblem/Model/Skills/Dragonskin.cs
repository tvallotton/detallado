

using Fire_Emblem;



public class Dragonskin : BaseSkill {
    public override string name { get; } = "Dragonskin";

    public override BaseCondition condition { get; } = new OnRivalsTurn().Or(new OnHighRivalHP(75));

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Spd = 6,
                Def = 6,
                Res = 6
            }
        };
    }
    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            neutralizedBonus = Stats<bool>.All(),
        };
    }

}