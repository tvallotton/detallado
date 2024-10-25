

using Fire_Emblem;

class GoldenLotus : BaseSkill {
    public override string name { get; } = "Golden Lotus";

    public override BaseCondition condition { get; } = new OnRivalWeapon(Weapon.Magic).Not();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            percentDamageReduction = 50,
            scope = Scope.FIRST_ATTACK
        };
    }
}