

using Fire_Emblem;

class LanceAgility : BaseSkill {
    public override string Name { get; } = "Lance Agility";

    public override BaseCondition Condition() {
        return new OnFighterWeapon(Weapon.Lance);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 12;
        effect.difference.Atk = -6;
        return effect;
    }

}