

using Fire_Emblem;

class BracingBlow : BaseSkill {
    public override string name { get; } = "Bracing Blow";


    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 6,
                Res = 6
            }
        };
    }

}