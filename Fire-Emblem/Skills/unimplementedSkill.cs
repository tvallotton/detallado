
using Fire_Emblem;

public class UnimplementedSkill : BaseSkill {

    public override string Name { get; }

    public UnimplementedSkill(string name) {
        Name = name;
    }


    public override BaseCondition Condition { get; } = new Always().Not();
}