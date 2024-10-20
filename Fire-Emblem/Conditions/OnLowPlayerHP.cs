
using Fire_Emblem;

public class OnPlayerLowHP : BaseCondition {
    private int _hp;

    public OnPlayerLowHP(int hp) {
        _hp = hp;
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).PercentageHP() <= _hp;
    }
}

