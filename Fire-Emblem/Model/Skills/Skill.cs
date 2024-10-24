


using System.Diagnostics;
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
        new AttackPlus6(),
        new SpeedPlus5(),
        new FairFight(),
        new BracingBlow(),
        new BrazenAtkSpd(),
        new BrazenAtkDef(),
        new BrazenAtkRes(),
        new BrazenSpdDef(),
        new BrazenSpdRes(),
        new BrazenDefRes(),
        new LifeAndDeath(),
        new FortDefRef(),
        new StillWater(),
        new Resolve(),
        new SwiftSparrow(),
        new CloseDef(),
        new DistantDef(),
        new LullAtkSpd(),
        new LullAtkDef(),
        new LullAtkRes(),
        new LullSpdRes(),
        new LullDefRes(),
        new LightAndDark(),
        new LullSpdDef(),
        new SwordAgility(),
        new BeorcsBlessing(),
        new AgneasArrow(),
        new Dragonskin(),
        new SwordFocus(),
        new SwordPower(),
        new LancePower(),
        new LanceAgility(),
        new AxePower(),
        new BowAgility(),
        new BowFocus(),
        new SolidGround(),
        new SturdyBow(),
        new EarthBoost(),
        new WardingBlow(),
        new DeadlyBlade(),
        new Wrath(),
        new SingleMinded(),
        new Charmer(),
        new Perceptive()
};

    public Skill(string name) {
        skill = SKILLS
            .FirstOrDefault((skill) => skill.Name == name)
            ?? new UnimplementedSkill(name);
    }

    public string Name() {
        return skill.Name;
    }

    public string? Install(Game game, int player) {
        return skill.Install(game, player);
    }
}
