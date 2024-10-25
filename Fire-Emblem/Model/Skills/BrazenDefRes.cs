

using Fire_Emblem;

class BrazenDefRes : BaseSkill {
    public override string name { get; } = "Brazen Def/Res";


    public override BaseCondition condition { get; } = new OnPlayerLowHP(80);

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Res = 10,
                Def = 10
            }
        };
    }

}