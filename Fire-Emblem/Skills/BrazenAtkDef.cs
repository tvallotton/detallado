

using Fire_Emblem;

class BrazenAtkDef : BaseSkill {
    public override string Name { get; } = "Brazen Atk/Def";

    public override BaseCondition Condition { get; } = new OnPlayerLowHP(80);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 10,
                Atk = 10
            }
        };
    }

}