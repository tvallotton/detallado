

using Fire_Emblem;

class Dragonskin : BaseSkill {
    public override string Name() {
        return "Dragonskin";
    }

    public override bool Condition(Game game, int player) {
        var rivalStarts = game.turn != player;
        var rivalHP = game.Fighter(player + 1).PercentageHP();
        return rivalStarts || 75 < rivalHP;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Atk = 6;
        effect.diff.Spd = 6;
        effect.diff.Def = 6;
        effect.diff.Res = 6;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralize.bonus = Values<bool>.All();
        return effect;
    }

}