

using Fire_Emblem;

class SimpleSkill : BaseSkill {

    private Effect[] _effect;

    public SimpleSkill(string name, BaseCondition condition, Effect[] playerEffect) {
        this.name = name;
        this.condition = condition;
        _effect = playerEffect;
    }
    public override string name { get; } = "Simple Skill";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        return _effect;
    }

}
