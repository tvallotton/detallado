
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
        return [];
    }

    public virtual IEnumerable<Effect> RivalEffects(Game game, int player) {
        return [];
    }

    public void Install(Game game, int player, EffectDependency dependencies) {
        if (condition.Holds(game, player, dependencies))
            AddEffects(game, player);
    }

    void AddEffects(Game game, int player) {
        foreach (var effect in PlayerEffects(game, player)) {
            effect.name = $"{game.Fighter(player)} {name}";
            Console.WriteLine($"add effects {effect}");
            game.Fighter(player).AddEffect(effect);
        }

        foreach (var effect in RivalEffects(game, player)) {
            effect.name = name;
            game.Fighter(player + 1).AddEffect(effect);
        }

    }
}

