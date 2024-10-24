

using Fire_Emblem;

class LifeAndDeath : BaseSkill {
    public override string Name { get; } = "Life and Death";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 6,
                Spd = 6,
                Def = -5,
                Res = -5
            }
        };
    }

}