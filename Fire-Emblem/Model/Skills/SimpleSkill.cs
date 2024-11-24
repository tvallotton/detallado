

using Fire_Emblem;

class SimpleSkill : BaseSkill {

    private Func<GameState, int, Effect[]> _effect;

    public SimpleSkill(string name, BaseCondition condition, Effect[] playerEffect) {
        this.name = name;
        this.condition = condition;
        _effect = (_game, _player) => playerEffect;
    }

    public SimpleSkill(string name, BaseCondition condition, Effect playerEffect) {
        this.name = name;
        this.condition = condition;
        _effect = (_game, _player) => [playerEffect];
    }

    public SimpleSkill(string name, BaseCondition condition, Func<GameState, int, Effect[]> playerEffects) {
        this.name = name;
        this.condition = condition;
        _effect = playerEffects;
    }

    public SimpleSkill(string name, BaseCondition condition, Func<GameState, int, Effect> playerEffects) {
        this.name = name;
        this.condition = condition;
        _effect = (game, player) => [playerEffects(game, player)];
    }


    public override string name { get; } = "Simple Skill";

    public override BaseCondition condition { get; } = new Always();

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        return _effect(game, player);
    }

}
