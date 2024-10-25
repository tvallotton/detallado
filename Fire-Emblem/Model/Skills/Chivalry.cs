

using Fire_Emblem;

class Chivalry : BaseSkill {
    public override string name { get; } = "Chivalry";
    public override BaseCondition condition => new OnPlayersTurn().And(new OnHighRivalHP(100));

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            extraDamage = 2,
            absoluteDamageReduction = 2,
        };
    }
}