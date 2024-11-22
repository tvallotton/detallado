

using Fire_Emblem;

class SimplePenalty : BaseSkill {

    private Func<Game, int, Effect[]> _effectFactory;

    public SimplePenalty(string name, BaseCondition condition, Effect[] rivalEffects) {
        this.name = name;
        this.condition = condition;
        _effectFactory = (_game, _payer) => rivalEffects;
    }

    public SimplePenalty(string name, BaseCondition condition, Effect rivalEffect) {
        this.name = name;
        this.condition = condition;
        _effectFactory =  (_game, _payer) => [rivalEffect];
    }

    public SimplePenalty(string name, BaseCondition condition,  Func<Game, int, Effect> rivalEffect) {
        this.name = name;
        this.condition = condition;
        _effectFactory =  (game, player) => [rivalEffect(game, player)];
    }

    public override string name { get; } = "Penalty Skill";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        return _effectFactory(game, player);
    }

}
