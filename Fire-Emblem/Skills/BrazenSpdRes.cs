

using Fire_Emblem;

class BrazenSpdRes : BaseSkill {
    public override string Name { get; } = "Brazen Spd/Res";


    public override BaseCondition Condition { get; } = new OnPlayerLowHP(80);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = 10,
                Spd = 10
            }
        };
    }

}