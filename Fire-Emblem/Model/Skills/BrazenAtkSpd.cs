

using Fire_Emblem;

class BrazenAtkSpd : BaseSkill {
    public override string name { get; } = "Brazen Atk/Spd";


    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Spd = 10,
                Atk = 10
            }
        };
    }

}