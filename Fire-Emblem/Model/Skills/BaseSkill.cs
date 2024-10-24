
using System.Diagnostics.Contracts;
using Fire_Emblem;

enum SkillType {
    Bonus, Penalty,
}

public abstract class BaseSkill {

    public virtual string Name { get; } = "";

    public virtual BaseCondition Condition { get; } = new Always();



    public virtual Effect PlayerEffect(Game game, int player) {
        return new Effect();
    }
    public virtual Effect RivalEffect(Game game, int player) {
        return new Effect();
    }

    public string? Install(Game game, int player) {
        if (Condition.Check(game, player)) {
            Console.WriteLine($"{Name} was installed for {game.Fighter(player)}");
            AddEffects(game, player);
        } else {
            Console.WriteLine($"{Name} was not installed for {game.Fighter(player)}: {Condition.Check(game, player)}");
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

