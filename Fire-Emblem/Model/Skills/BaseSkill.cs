
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public virtual string name { get; } = "";

    public virtual BaseCondition condition { get; } = new Always();


    public virtual Effect PlayerEffect(Game game, int player) {
        return new Effect();
    }

    public virtual Effect RivalEffect(Game game, int player) {
        return new Effect();
    }

    public void Install(Game game, int player, EffectDependency dependencies) {
        if (condition.Holds(game, player, dependencies))
            AddEffects(game, player);
    }

    void AddEffects(Game game, int player) {
        var playerEff = PlayerEffect(game, player);
        game.Fighter(player).AddEffect(playerEff);


        var rivalEff = RivalEffect(game, player);
        game.Fighter(player + 1).AddEffect(rivalEff);

    }
}

