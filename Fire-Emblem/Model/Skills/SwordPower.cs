

using Fire_Emblem;

class SwordPower : BaseSkill {
    public override string name { get; } = "Sword Power";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}