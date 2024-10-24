

using Fire_Emblem;

class Perceptive : BaseSkill {
    public override string Name { get; } = "Perceptive";

    public override BaseCondition Condition { get; } = new OnPlayersTurn();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 12 + game.Fighter(player).Get(Stat.Spd) / 4,
            }
        };
    }

}