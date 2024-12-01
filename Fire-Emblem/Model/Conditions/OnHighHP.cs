
using Fire_Emblem;

public class OnHighHP(Subject subject, int hp) : BaseCondition {

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player + (int)subject).GetPercentageHP() >= hp;
    }
}

