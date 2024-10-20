

using Fire_Emblem;

class SwordPower : BaseSkill {
    public override string Name { get; } = "Sword Power";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Sword);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Def = -10;
        effect.difference.Atk = 10;
        return effect;
    }

}