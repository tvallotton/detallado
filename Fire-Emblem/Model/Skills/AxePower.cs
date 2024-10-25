

using Fire_Emblem;

class AxePower : BaseSkill {
    public override string name { get; } = "Axe Power";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Axe);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}