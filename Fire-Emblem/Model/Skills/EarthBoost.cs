

using Fire_Emblem;

class EarthBoost : BaseSkill {
    public override string name { get; } = "Earth Boost";

    public override BaseCondition condition { get; } = new OnHigherPlayerHP(byHowMuch: 3);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 6,
            }
        };
    }

}