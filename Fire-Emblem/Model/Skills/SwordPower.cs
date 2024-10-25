

using Fire_Emblem;

class SwordPower : BaseSkill {
    public override string name { get; } = "Sword Power";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}