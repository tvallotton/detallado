

using System.Diagnostics;
using Fire_Emblem;

class ExtraChivalry : BaseSkill {
    public override string name { get; } = "Extra Chivalry";

    public override BaseCondition condition => new Always();

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        var fighter = game.GetFighter(player + 1);
        var percentage = 100 * fighter.GetHP() / fighter.GetMaxHP();
        yield return new Effect {
            percentDamageReduction = percentage / 2,
        };
    }
}