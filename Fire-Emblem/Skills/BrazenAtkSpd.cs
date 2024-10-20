

using Fire_Emblem;

class BrazenAtkSpd : BaseSkill {
    public override string Name { get; } = "Brazen Atk/Spd";


    public override BaseCondition Condition() {
        return new OnPlayerLowHP(80);
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Spd = 10;
        effect.difference.Atk = 10;
        return effect;
    }

}