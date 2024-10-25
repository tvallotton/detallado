

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string name { get; } = "Armored Blow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 8
            }
        };
    }

}