

using Fire_Emblem;

class BowFocus : BaseSkill {
    public override string Name { get; } = "Bow Focus";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Bow);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Res = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}