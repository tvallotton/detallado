

using Fire_Emblem;

class DistantDef : BaseSkill {
    public override string Name() {
        return "Distant Def";
    }

    public override bool Condition(Game game, int player) {
        var rivalStarts = game.turn != player;
        var rivalWeapon = game.Fighter(player + 1).Weapon();
        return rivalStarts && (rivalWeapon == Weapon.Magic || rivalWeapon == Weapon.Bow);
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