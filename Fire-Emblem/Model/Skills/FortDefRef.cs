

using Fire_Emblem;

class FortDefRef : BaseSkill {
    public override string Name { get; } = "Fort. Def/Res";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = -2,
                Def = 6,
                Res = 6
            }
        };
    }

}