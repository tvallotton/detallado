

using Fire_Emblem;

class ResistancePlus5 : BaseSkill {
    public override string Name { get; } = "Resistance +5";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = 5
            }
        };
    }

}