
using Fire_Emblem;

public class UnimplementedSkill : BaseSkill {

    public override string name { get; }

    public UnimplementedSkill(string name) {
        this.name = name;
    }


    public override BaseCondition condition { get; } = new Never();
}