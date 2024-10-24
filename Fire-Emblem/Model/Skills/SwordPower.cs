

using Fire_Emblem;

class SwordPower : BaseSkill {
    public override string Name { get; } = "Sword Power";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Sword);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}