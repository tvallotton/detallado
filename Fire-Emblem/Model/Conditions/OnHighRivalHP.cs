
using Fire_Emblem;

public class OnHighRivalHP : BaseCondition {
    private int _hp;

    public OnHighRivalHP(int hp) {
        _hp = hp;
    }

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player + 1).GetPercentageHP() >= _hp;
    }
}

