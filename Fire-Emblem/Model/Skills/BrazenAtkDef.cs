

using Fire_Emblem;

class BrazenAtkDef : BaseSkill {
    public override string name { get; } = "Brazen Atk/Def";

    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 10,
                Atk = 10
            }
        };
    }

}