

using Fire_Emblem;

class BrazenAtkRes : BaseSkill {
    public override string Name { get; } = "Brazen Atk/Res";


    public override BaseCondition Condition() {
        return new OnPlayerLowHP(80);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Res = 10;
        effect.difference.Atk = 10;
        return effect;
    }

}