

using Fire_Emblem;

class LullDefRes : BaseSkill {
    public override string Name { get; } = "Lull Def/Res";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -3,
                Res = -3,
            },
            neutralizedBonus = new Stats<bool> {
                Def = true,
                Res = true,
            }
        };
    }

}