

using Fire_Emblem;

class AegisShield : BaseSkill {
    public override string name { get; } = "Aegis Shield";

    public override Effect PlayerEffect(Game game, int player) {
        return new Effect {
            difference = new Stats<int> {
                Def = 6,
                Res = 3,
            },
            scope = Scope.FIRST_ATTACK
        };
    }
}