

using Fire_Emblem;

class AxePower : BaseSkill {
    public override string Name { get; } = "Axe Power";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Axe);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}