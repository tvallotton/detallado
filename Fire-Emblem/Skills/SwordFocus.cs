

using Fire_Emblem;

class SwordFocus : BaseSkill {
    public override string Name() {
        return "Sword Focus";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Sword;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Res = -10;
        effect.diff.Atk = 10;
        return effect;
    }

}