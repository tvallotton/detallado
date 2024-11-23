
using Fire_Emblem;

public class OnPlayerHighHP : BaseCondition {
    private int _hp;

    public OnPlayerHighHP(int hp) {
        _hp = hp;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).GetPercentageHP() >= _hp;
    }
}

