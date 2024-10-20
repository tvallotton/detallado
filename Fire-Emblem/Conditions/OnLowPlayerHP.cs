
using Fire_Emblem;

public class OnLowHP: BaseCondition {
    private int _hp;

    public OnLowHP(int hp)  {
        _hp = hp;
    }

    public override bool Condition(Game game, int player) {
         return game.Fighter(player).PercentageHP() <= _hp;
    }
}

