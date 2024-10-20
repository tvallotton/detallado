
using Fire_Emblem;

public class OnHighRivalHP : BaseCondition {
    private int _hp;

    public OnHighRivalHP(int hp) {
        _hp = hp;
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player + 1).PercentageHP() <= _hp;
    }
}

