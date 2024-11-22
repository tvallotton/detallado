

using Fire_Emblem;

class FairFight : BaseSkill {
    public override string name { get; } = "Fair Fight";

    public override BaseCondition condition { get; } = new OnPlayersTurn();

    public override IEnumerable<Effect> PlayerEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6
            }
        };
    }
    public override IEnumerable<Effect> RivalEffects(Game game, int player) {
        yield return new Effect {
            difference = new Stats<int> {
                Atk = 6
            }
        };
    }

}