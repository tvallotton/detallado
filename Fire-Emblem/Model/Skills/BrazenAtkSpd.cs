

using Fire_Emblem;

class BrazenAtkSpd : BaseSkill {
    public override string Name { get; } = "Brazen Atk/Spd";


    public override BaseCondition Condition { get; } = new OnPlayerLowHP(80);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Spd = 10,
                Atk = 10
            }
        };
    }

}