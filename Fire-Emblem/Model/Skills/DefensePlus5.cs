

using Fire_Emblem;

class DefensePlus5 : BaseSkill {
    public override string name { get; } = "Defense +5";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 5
            }
        };
    }

}