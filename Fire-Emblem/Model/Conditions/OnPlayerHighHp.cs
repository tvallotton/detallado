
using Fire_Emblem;

public class OnPlayerHighHP : BaseCondition {
    private int _hp;

    public OnPlayerHighHP(int hp) {
        _hp = hp;
    }

    protected internal override bool Check(GameState game, int player) {
        Console.WriteLine($"DEBUG: {game.GetFighter(player)} {game.GetFighter(player).GetPercentageHP()}");
        return game.GetFighter(player).GetPercentageHP() >= _hp;
    }
}

