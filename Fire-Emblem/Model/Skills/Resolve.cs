

using Fire_Emblem;

class Resolve : BaseSkill {
    public override string name { get; } = "Resolve";

    public override BaseCondition condition { get; } = new OnPlayerLowHP(75);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 7,
                Res = 7,
            }
        };

    }

}