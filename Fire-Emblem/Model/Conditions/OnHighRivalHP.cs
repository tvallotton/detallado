
using Fire_Emblem;

public class OnHighRivalHP : BaseCondition {
    private int _hp;

    public OnHighRivalHP(int hp) {
        _hp = hp;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player + 1).GetPercentageHP() >= _hp;
    }
}

