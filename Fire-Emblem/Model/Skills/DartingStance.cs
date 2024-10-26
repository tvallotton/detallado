

using System.Diagnostics;
using Fire_Emblem;

class DartingStance : BaseSkill {
    public override string name { get; } = "Darting Stance";

    public override BaseCondition condition { get; } = new OnRivalsTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 8
            },
        };
        yield return new Effect {
            percentDamageReduction = 10,
            scope = Scope.FOLLOW_UP,
        };
    }

}