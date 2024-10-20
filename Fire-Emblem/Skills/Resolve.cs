

using Fire_Emblem;

class Resolve : BaseSkill {
    public override string Name() {
        return "Resolve";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).PercentageHP() <= 75;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = 7;
        effect.difference.Res = 7;
        return effect;
    }

}