

using Fire_Emblem;

class Wrath : BaseSkill {
    public override string name { get; } = "Wrath";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        var damage = Math.Min(game.Fighter(player).GetAccumulatedDamage(), 30);
        yield return new Effect {
            difference = new Stats<int> {
                Atk = damage,
                Spd = damage,
            }
        };
    }

}