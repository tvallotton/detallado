
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public virtual string name { get; } = "";

    public virtual BaseCondition condition { get; } = new Always();


    public virtual IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect();
    }

    public virtual IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect();
    }

    public void Install(Game game, int player, EffectDependency dependencies) {
        if (condition.Holds(game, player, dependencies))
            AddEffects(game, player);
    }

    void AddEffects(Game game, int player) {
        foreach (var effect in PlayerEffects(game, player)) {
            game.Fighter(player).AddEffect(effect);
        }

        foreach (var effect in RivalEffects(game, player)) {
            game.Fighter(player + 1).AddEffect(effect);
        }

    }
}

