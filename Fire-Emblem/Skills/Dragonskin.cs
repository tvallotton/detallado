

using Fire_Emblem;

class Dragonskin : BaseSkill {
    public override string Name { get; } = "Dragonskin";

    public override bool Condition(Game game, int player) {
        var rivalStarts = game.turn != player;
        var rivalHP = game.Fighter(player + 1).PercentageHP();
        return rivalStarts || 75 < rivalHP;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Atk = 6;
        effect.difference.Spd = 6;
        effect.difference.Def = 6;
        effect.difference.Res = 6;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}