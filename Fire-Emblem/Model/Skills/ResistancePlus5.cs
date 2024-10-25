

using Fire_Emblem;

class ResistancePlus5 : BaseSkill {
    public override string name { get; } = "Resistance +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = 5
            }
        };
    }

}