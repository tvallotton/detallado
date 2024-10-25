

using Fire_Emblem;

class AegisShield : BaseSkill {
    public override string name { get; } = "Aegis Shield";

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Def = 6,
                Res = 3,
            },
            scope = Scope.FIRST_ATTACK
        };
    }
}