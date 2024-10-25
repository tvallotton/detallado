
using System.Diagnostics.Contracts;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public virtual string name { get; } = "";

    public virtual BaseCondition? condition { get; } = null;

    public virtual BaseCondition? postCondition { get; } = null;


    public virtual Effect PlayerEffect(Game game, int player) {
        return new Effect();
    }

    public virtual Effect RivalEffect(Game game, int player) {
        return new Effect();
    }

    public void InstallOnStats(Game game, int player) {
        if (condition != null && condition.Check(game, player))
            AddEffects(game, player);
    }


    public void InstallOnDamage(Game game, int player) {
        if (postCondition != null && postCondition.Check(game, player))
            AddEffects(game, player);
    }


    void AddEffects(Game game, int player) {
        var playerEff = PlayerEffect(game, player);
        game.Fighter(player).AddEffect(playerEff);


        var rivalEff = RivalEffect(game, player);
        game.Fighter(player + 1).AddEffect(rivalEff);

    }
}

