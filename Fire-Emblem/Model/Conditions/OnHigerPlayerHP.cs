
using Fire_Emblem;

public class OnHigherPlayerHP : BaseCondition {
    private int _byHowMuch;

    public OnHigherPlayerHP(int byHowMuch) {
        _byHowMuch = byHowMuch;
    }

    protected internal override bool Check(Game game, int player) {
        return game.Fighter(player).GetHP() > game.Fighter(player + 1).GetHP() + 3;
    }
}
