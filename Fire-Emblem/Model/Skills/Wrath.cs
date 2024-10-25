

using Fire_Emblem;

class Wrath : BaseSkill {
    public override string name { get; } = "Wrath";

    public override BaseCondition condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        var damage = Math.Min(game.Fighter(player).GetAccumulatedDamage(), 30);
        return new Effect {
            difference = new Stats<int> {
                Atk = damage,
                Spd = damage,
            }
        };
    }

}