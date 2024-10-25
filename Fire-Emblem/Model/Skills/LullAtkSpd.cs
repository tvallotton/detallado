

using Fire_Emblem;

class LullAtkSpd : BaseSkill {
    public override string name { get; } = "Lull Atk/Spd";

    public override BaseCondition condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {

        return new Effect {
            difference = new Stats<int> {
                Spd = -3,
                Atk = -3,
            },
            neutralizedBonus = new Stats<bool> {
                Spd = true,
                Atk = true
            }
        };
    }

}