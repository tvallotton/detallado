

using System.Net.Http.Headers;
using Fire_Emblem;

class LullAtkDef : BaseSkill {
    public override string Name { get; } = "Lull Atk/Def";

    public override BaseCondition Condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -3,
                Atk = -3,
            },
            neutralizedBonus = new Stats<bool> {
                Def = true,
                Atk = true,
            }
        };
    }

}