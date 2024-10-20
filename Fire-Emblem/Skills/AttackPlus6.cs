

using Fire_Emblem;

class AttackPlus6 : BaseSkill {
    public override string Name() {
        return "Attack +6";
    }


    public override bool Condition(Game game, int player) {
        return true;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();

        effect.difference.Atk = 6;
        return effect;
    }

}