

using Fire_Emblem;

class GoldenLotus : BaseSkill {
    public override string name { get; } = "Golden Lotus";

    public override BaseCondition condition { get; } = new OnRivalWeapon(Weapon.Magic).Not();

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            percentDamageReduction = 50,
            scope = Scope.FIRST_ATTACK
        };
    }
}