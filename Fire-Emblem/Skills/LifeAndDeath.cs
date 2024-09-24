

using Fire_Emblem;

class LifeAndDeath : BaseSkill {
    public override string Name() {
        return "Life and Death";
    }

    public override string? Anounce(Game game, int player) {
        return $"{game.Fighter(player)} obtiene Atk+6\n"
        + $"{game.Fighter(player)} obtiene Spd+6\n"
        + $"{game.Fighter(player)} obtiene Def-5\n"
        + $"{game.Fighter(player)} obtiene Res-5";


    }

    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.Atk = 6;
        effect.Spd = 6;
        effect.Def = -5;
        effect.Res = -5;
        return effect;
    }

}