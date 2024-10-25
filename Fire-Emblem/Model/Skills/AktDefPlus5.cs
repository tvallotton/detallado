

using Fire_Emblem;

class AktDefPlus5 : BaseSkill {
    public override string name { get; } = "Atk/Def +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 5,
                Atk = 5
            }
        };
    }

}