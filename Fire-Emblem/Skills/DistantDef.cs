

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
        effect.difference.Def = 8;
        effect.difference.Res = 8;
        return effect;
    }
    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.neutralized.bonus = Stats<bool>.All();
        return effect;
    }

}