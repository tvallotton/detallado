

using Fire_Emblem;

class AxePower : BaseSkill {
    public override string Name() {
        return "Axe Power";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Axe;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Def = -10;
        effect.diff.Atk = 10;
        return effect;
    }

}