

using Fire_Emblem;

class AktResPlus5 : BaseSkill {
    public override string name { get; } = "Atk/Res +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = 5,
                Atk = 5
            }
        };
    }

}