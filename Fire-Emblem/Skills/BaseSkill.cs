
using System.Diagnostics.Contracts;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public abstract string Name();

    public virtual string? Anounce(Game game, int player) {
        return null;
    }

    public abstract bool Condition(Game game, int player);

    public virtual Effect PlayerEffect(Game game, int player) {
        return new Effect();
    }
    public virtual Effect RivalEffect(Game game, int player) {
        return new Effect();
    }

    public string? Install(Game game, int player) {
        int rival = (player + 1) & 1;
        if (Condition(game, player)) {
            AddEffects(game, player);
            return Anounce(game, player);
        }
        return null;
    }
    void AddEffects(Game game, int player) {
        var playerEff = PlayerEffect(game, player);
        game.Fighter(player).AddEffect(playerEff);


        var rivalEff = RivalEffect(game, player);
        game.Fighter(player + 1).AddEffect(rivalEff);

    }
}

