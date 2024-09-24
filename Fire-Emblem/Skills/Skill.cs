


using Fire_Emblem;

public class Skill {

    BaseSkill skill;

    static BaseSkill[] SKILLS = {
        new ArmoredBlow(),
        new AktDefPlus5(),
        new AktResPlus5(),
        new SpdResPlus5(),
        new DefensePlus5(),
        new ResistancePlus5(),
};

    public Skill(string name) {
        skill = SKILLS
            .FirstOrDefault((skill) => skill.Name() == name)
            ?? new UnimplementedSkill(name);
    }

    public string Name() {
        return skill.Name();
    }

    public string? Install(Game game, int player) {
        return skill.Install(game, player);
    }
}
