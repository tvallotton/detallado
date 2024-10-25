

using Fire_Emblem;

class BrazenSpdDef : BaseSkill {
    public override string name { get; } = "Brazen Spd/Def";


    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 10,
                Spd = 10
            }
        };
    }

}