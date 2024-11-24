

using System.Diagnostics;
using Fire_Emblem;

class DragonsWrath : BaseSkill {
    public override string name { get; } = "Dragon's Wrath";

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        yield return new Effect {
            percentDamageReduction = 25,
            scope = Scope.FIRST_ATTACK,
        };

        int atk = game.GetFighter(player).Get(Stat.Atk);
        int res = game.GetFighter(player + 1).Get(Stat.Res);

        if (atk > res)
            yield return new Effect {
                extraDamage = (int)Math.Floor(0.25 * (atk - res)),
                scope = Scope.FIRST_ATTACK,
            };
    }


}