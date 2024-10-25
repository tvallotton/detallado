

using Fire_Emblem;

class Perceptive : BaseSkill {
    public override string name { get; } = "Perceptive";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12 + game.Fighter(player).Get(Stat.Spd) / 4,
            }
        };
    }

}