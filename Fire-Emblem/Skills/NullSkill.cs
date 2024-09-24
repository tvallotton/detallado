
using Fire_Emblem;

public class UnimplementedSkill : BaseSkill {

    string name;

    public UnimplementedSkill(string name) {
        this.name = name;
    }

    public override string Name() {
        return name;
    }

    public override bool Condition(Game game, int player) {
        return false;
    }
}