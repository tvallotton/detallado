

using Fire_Emblem;

class LifeAndDeath : BaseSkill {
    public override string name { get; } = "Life and Death";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Spd = 6,
                Def = -5,
                Res = -5
            }
        };
    }

}