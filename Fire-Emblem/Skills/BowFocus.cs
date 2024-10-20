

using Fire_Emblem;

class BowFocus : BaseSkill {
    public override string Name() {
        return "Bow Focus";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Bow;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Res = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}