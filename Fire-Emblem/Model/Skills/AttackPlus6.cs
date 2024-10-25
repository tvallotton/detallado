

using Fire_Emblem;

class AttackPlus6 : BaseSkill {
    public override string name { get; } = "Attack +6";


    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6
            }
        };
    }

}