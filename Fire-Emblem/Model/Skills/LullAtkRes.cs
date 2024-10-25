

using Fire_Emblem;

class LullAtkRes : BaseSkill {
    public override string name { get; } = "Lull Atk/Res";

    public override BaseCondition condition { get; } = new Always();

    public override Effect RivalEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Res = -3;
        effect.difference.Atk = -3;
        effect.neutralizedBonus.Res = true;
        effect.neutralizedBonus.Atk = true;
        return effect;
    }

}