
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public virtual string name { get; } = "";

    public virtual BaseCondition condition { get; } = new Always();


    public virtual IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        return [];
    }

    public virtual IEnumerable<Effect> RivalEffects(GameState game, int player) {
        return [];
    }

    public void Register(GameState game, int player, EffectDependency dependencies) {
        if (condition.Holds(game, player, dependencies))
            AddEffects(game, player);
    }

    void AddEffects(GameState game, int player) {
        foreach (var effect in PlayerEffects(game, player)) {
            game.GetFighter(player).AddEffect(effect);
        }

        foreach (var effect in RivalEffects(game, player)) {
            game.GetFighter(player + 1).AddEffect(effect);
        }

    }
}

