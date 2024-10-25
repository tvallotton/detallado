

using Fire_Emblem;

class SolidGround : BaseSkill {
    public override string name { get; } = "Solid Ground";

    public override BaseCondition condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = -5,
                Atk = +6,
                Def = +6,
            }
        };
    }

}