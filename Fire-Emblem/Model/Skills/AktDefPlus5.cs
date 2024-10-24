

using Fire_Emblem;

class AktDefPlus5 : BaseSkill {
    public override string Name { get; } = "Atk/Def +5";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 5,
                Atk = 5
            }
        };
    }

}