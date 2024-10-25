

using Fire_Emblem;

class BracingStance : BaseSkill {
    public override string name { get; } = "Bracing Stance";

    public override BaseCondition condition { get; } = new OnRivalsTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 6,
                Res = 6
            }
        };
        yield return new Effect {
            percentDamageReduction = 10,
            scope = Scope.FOLLOW_UP
        };
    }

}