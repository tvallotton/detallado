

using Fire_Emblem;

class BrazenSpdDef : BaseSkill {
    public override string Name { get; } = "Brazen Spd/Def";


    public override BaseCondition Condition() {
        return new OnPlayerLowHP(80);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Def = 10;
        effect.difference.Spd = 10;
        return effect;
    }

}