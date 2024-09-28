

using Fire_Emblem;

class CloseDef : BaseSkill {
    public override string Name() {
        return "Close Def";
    }

    public override bool Condition(Game game, int player) {
        Weapon[] weapons = { Weapon.Axe, Weapon.Lance, Weapon.Sword };
        var fighter = game.Fighter(player + 1);
        return game.turn != player && weapons.Contains(fighter.Weapon());
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Def = 8;
        effect.diff.Res = 8;
        return effect;
    }

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralize.bonus = Values<bool>.All();
        return effect;
    }

}