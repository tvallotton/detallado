

using Fire_Emblem;

class FairFight : BaseSkill {
    public override string name { get; } = "Fair Fight";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 5
            }
        };
    }
    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 5
            }
        };
    }

}