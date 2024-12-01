
using Fire_Emblem;

public class OnHighAbsoluteHP(Subject subject, int hp) : BaseCondition {

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player + (int)subject).GetHP() >= hp;
    }
}

