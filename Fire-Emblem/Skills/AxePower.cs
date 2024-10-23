

using Fire_Emblem;

class AxePower : BaseSkill {
    public override string Name { get; } = "Axe Power";

    public override BaseCondition Condition { get; } = new OnFighterWeapon(Weapon.Axe);

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = -10,
                Atk = 10
            }
        };
    }

}