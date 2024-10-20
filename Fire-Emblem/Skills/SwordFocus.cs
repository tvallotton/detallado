

using Fire_Emblem;

class SwordFocus : BaseSkill {
    public override string Name { get; } = "Sword Focus";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Sword);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Res = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}