
using Fire_Emblem;

public class OnHigherPlayerHP : BaseCondition {
    private int _byHowMuch;

    public OnHigherPlayerHP(int byHowMuch) {
        _byHowMuch = byHowMuch;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).HP() > game.Fighter(player + 1).HP() + 3;
    }
}

