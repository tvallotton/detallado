

using Fire_Emblem;

class BracingBlow : BaseSkill {
    public override string name { get; } = "Bracing Blow";


    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 6,
                Res = 6
            }
        };
    }

}