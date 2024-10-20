

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string Name { get; } = "Bow Agility";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Bow);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 12;
        effect.difference.Atk = -6;
        return effect;
    }

}