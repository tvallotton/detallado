
using Fire_Emblem;

public class OnHigherPlayerHP : BaseCondition {
    private int _byHowMuch;

    public OnHigherPlayerHP(int byHowMuch) {
        _byHowMuch = byHowMuch;
    }

    protected internal override bool Check(GameState game, int player) {
        return game.GetFighter(player).GetHP() > game.GetFighter(player + 1).GetHP() + _byHowMuch;
    }
}

