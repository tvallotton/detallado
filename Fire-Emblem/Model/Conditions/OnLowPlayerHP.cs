
using Fire_Emblem;

public class OnPlayerLowHP : BaseCondition {
    private int _hp;

    public OnPlayerLowHP(int hp) {
        _hp = hp;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).GetPercentageHP() <= _hp;
    }
}

