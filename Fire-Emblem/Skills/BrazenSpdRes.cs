

using Fire_Emblem;

class BrazenSpdRes : BaseSkill {
    public override string Name() {
        return "Brazen Spd/Res";
    }


    public override bool Condition(Game game, int player) {
        return game.Fighter(player).PercentageHP() <= 80;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Res = 10;
        effect.difference.Spd = 10;
        return effect;
    }

}