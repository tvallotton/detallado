

using Fire_Emblem;

class ArmoredBlow : BaseSkill {
    public override string name { get; } = "Armored Blow";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 8
            }
        };
    }

}