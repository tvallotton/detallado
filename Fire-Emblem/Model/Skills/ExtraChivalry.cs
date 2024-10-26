

using System.Diagnostics;
using Fire_Emblem;

class ExtraChivalry : BaseSkill {
    public override string name { get; } = "Extra Chivalry";

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        int rivalHp = game.Fighter(player + 1).GetPercentageHP();


        if (game.Fighter(player + 1).GetPercentageHP() >= 50) {
            yield return new Effect {
                difference = new Stats<int> {
                    Atk = -5,
                    Spd = -5,
                    Def = -5,
                }
            };
        }

        yield return new Effect {
            percentDamageReduction = rivalHp / 2,
        };
    }


}