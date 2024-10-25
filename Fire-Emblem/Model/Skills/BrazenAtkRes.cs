

using Fire_Emblem;

class BrazenAtkRes : BaseSkill {
    public override string name { get; } = "Brazen Atk/Res";


    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Res = 10,
                Atk = 10
            }
        };
    }

}