

using Fire_Emblem;

class DefensePlus5 : BaseSkill {
    public override string Name { get; } = "Defense +5";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 5
            }
        };
    }

}