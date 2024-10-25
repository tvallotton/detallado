

using Fire_Emblem;

class StillWater : BaseSkill {
    public override string name { get; } = "Still Water";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Res = 6,
                Def = -2
            }
        };
    }

}