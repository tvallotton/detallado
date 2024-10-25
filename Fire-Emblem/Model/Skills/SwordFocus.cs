

using Fire_Emblem;

class SwordFocus : BaseSkill {
    public override string name { get; } = "Sword Focus";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Sword);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = -10,
                Atk = 10,
            }
        };
    }

}