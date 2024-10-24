

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string Name { get; } = "Atk/Res +5";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = 5,
                Atk = 5
            }
        };
    }

}