

using Fire_Emblem;

class LancePower : BaseSkill {
    public override string Name { get; } = "Lance Power";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Lance);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}