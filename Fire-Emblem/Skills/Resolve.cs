

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
        effect.diff.Def = 7;
        effect.diff.Res = 7;
        return effect;
    }

}