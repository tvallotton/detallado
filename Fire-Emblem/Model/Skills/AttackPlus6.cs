

using Fire_Emblem;

class AttackPlus6 : BaseSkill {
    public override string Name { get; } = "Attack +6";


    public override BaseCondition Condition { get; } = new Always();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Atk = 6
            }
        };
    }

}