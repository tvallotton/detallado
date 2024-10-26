


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
        new Perceptive(),
        new Dodge(),
        new DragonWall(),
        new GoldenLotus(),
        new AegisShield(),
        new BlueSkies(),
        new BracingStance(),
        new Bushido(),
        new Chivalry(),
        new DartingStance(),
        new DragonsWrath(),
        new SimpleSkill(
            "Remote Mirror",
            new OnPlayersTurn(),
            [
                new Effect { difference = new Stats<int> {Atk = 7, Res = 10} },
                new Effect { percentDamageReduction = 30, scope = Scope.FIRST_ATTACK }
            ]
        ),
        new SimpleSkill(
            "Magic Guard",
            new OnRivalWeapon(Weapon.Magic),
            [new Effect { absoluteDamageReduction = 5, }]
        ),
        new SimpleSkill(
            "Lance Guard",
            new OnRivalWeapon(Weapon.Lance),
            [new Effect { absoluteDamageReduction = 5, }]
        ),
        new SimpleSkill(
            "Axe Guard",
            new OnRivalWeapon(Weapon.Axe),
            [new Effect { absoluteDamageReduction = 5, }]
        ),

        new SimpleSkill(
            "Bow Guard",
            new OnRivalWeapon(Weapon.Bow),
            [new Effect { absoluteDamageReduction = 5 }]
        ),

        new SimpleSkill(
            "Gentility",
            new Always(),
            [new Effect { absoluteDamageReduction = 5 }]
        ),
        new SimpleSkill(
            "Sympathetic",
            new OnPlayerLowHP(50),
            [new Effect { absoluteDamageReduction = 5 }]
        ),

        new SimpleSkill(
            "Sympathetic",
            new OnPlayerLowHP(50),
            [new Effect { absoluteDamageReduction = 5 }]
        ),

        new SimpleSkill(
            "Bravery",
            new Always(),
            [new Effect { extraDamage = 5 }]
        ),

         new SimpleSkill(
            "Swift Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Spd = 6, Res=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Steady Posture",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Spd = 6, Def=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Mirror Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Res=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Sturdy Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Def=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Kestrel Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Spd=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),

        new SimpleSkill(
            "Warding Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Res = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),


        new SimpleSkill(
            "Steady Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Def = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Fierce Stance",
            new OnRivalsTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Remote Sturdy",
            new OnPlayersTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 7, Def= 10 } },
                new Effect { scope =Scope.FIRST_ATTACK , percentDamageReduction=30 },
            ]
        ),
        new SimpleSkill(
            "Remote Sparrow",
            new OnPlayersTurn(),
            [
                new Effect { difference = new Stats<int> { Atk = 7, Spd= 7 } },
                new Effect { scope =Scope.FIRST_ATTACK , percentDamageReduction=30 },
            ]
        ),





};

    public Skill(string name) {
        skill = SKILLS
            .FirstOrDefault((skill) => skill.name == name)
            ?? new UnimplementedSkill(name);
    }

    public string Name() {
        return skill.name;
    }

    public void Install(Game game, int player, EffectDependency dependency) {
        skill.Install(game, player, dependency);
    }


}
