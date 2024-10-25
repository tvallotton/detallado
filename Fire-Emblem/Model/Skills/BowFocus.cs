

using Fire_Emblem;

class BowFocus : BaseSkill {
    public override string name { get; } = "Bow Focus";

    public override BaseCondition condition { get; } = new OnPlayerWeapon(Weapon.Bow);


    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = -10,
                Atk = 10
            }
        };
    }

}