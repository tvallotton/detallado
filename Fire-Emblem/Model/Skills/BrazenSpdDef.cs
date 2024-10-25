

using Fire_Emblem;

class BrazenSpdDef : BaseSkill {
    public override string name { get; } = "Brazen Spd/Def";


    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 10,
                Spd = 10
            }
        };
    }

}