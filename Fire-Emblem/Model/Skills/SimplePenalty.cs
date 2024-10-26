

using Fire_Emblem;

class SimplePenalty : BaseSkill {

    private Effect[] _effect;

    public SimplePenalty(string name, BaseCondition condition, Effect[] rivalEffect) {
        this.name = name;
        this.condition = condition;
        _effect = rivalEffect;
    }

    public SimplePenalty(string name, BaseCondition condition, Effect rivalEffect) {
        this.name = name;
        this.condition = condition;
        _effect = [rivalEffect];
    }
    public override string name { get; } = "Penalty Skill";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        return _effect;
    }

}
