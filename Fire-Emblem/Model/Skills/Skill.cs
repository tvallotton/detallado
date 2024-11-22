


using System.Diagnostics;
using Fire_Emblem;

public class Skill {

    BaseSkill skill;

    static BaseSkill[] SKILLS = {
        new SimpleSkill(
            "Armored Blow",
            new OnPlayersTurn(),
            new Effect {
                difference = new Stats<int> {
                    Def = 8
                }
        }),
        new SimpleSkill(
            "Atk/Def +5",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Def = 5,
                    Atk = 5
                }
        }),
        new SimpleSkill(
            "Atk/Res +5",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Res = 5,
                    Atk = 5
                }
        }),
        new SimpleSkill(
            "Spd/Res +5",
            new Always(),
            new Effect {
            difference = new Stats<int> {
                Spd = 5,
                Res = 5,
            }
        }),
        new SimpleSkill(
            "Defense +5",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Def = 5
                }
            }
        ),
        new SimpleSkill(
            "Resistance +5",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Res = 5
                }
            }
        ),
        new SimpleSkill(
            "Attack +6",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Atk = 6
                }
            }
        ),
        new FairFight(),
        new SimpleSkill(
            "Bracing Blow",
            new OnPlayersTurn(),
            new Effect {
                difference = new Stats<int> {
                    Def = 6,
                    Res = 6
                }
            }
        ),
        new SimpleSkill(
            "Brazen Atk/Res",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Res = 10,
                    Atk = 10
                }
            }
        ),
        new SimpleSkill(
            "Brazen Atk/Def",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Def = 10,
                    Atk = 10
                }
            }
        ),

        new SimpleSkill(
            "Brazen Atk/Spd",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Spd = 10,
                    Atk = 10
                }
            }
        ),
        new SimpleSkill(
            "Brazen Spd/Res",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Res = 10,
                    Spd = 10
                }
            }
        ),
        new SimpleSkill(
            "Brazen Spd/Def",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Def = 10,
                    Spd = 10
                }
            }
        ),
        new SimpleSkill(
            "Brazen Def/Res",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Res = 10,
                    Def = 10
                }
            }
        ),
        new SimpleSkill(
            "Brazen Atk/Spd",
            new OnPlayerLowHP(80),
            new Effect {
                difference = new Stats<int> {
                    Spd = 10,
                    Atk = 10
                }
            }
        ),
        new SimpleSkill(
            "Resolve",
            new OnPlayerLowHP(75),
            new Effect {
                difference = new Stats<int> {
                    Def = 7,
                    Res = 7,
                }
            }
        ),
        new SimpleSkill(
            "Swift Sparrow",
            new OnPlayersTurn(),
            new Effect {
                    difference = new Stats<int> {
                    Atk = 6,
                    Spd = 6,
                }
            }
        ),

        new SimpleSkill(
            "Darting Stance",
            new OnRivalsTurn(),
            [
                new Effect {
                    difference = new Stats<int> {
                        Spd = 8
                    },
                },
                new Effect {
                    percentDamageReduction = 10,
                    scope = Scope.FOLLOW_UP,
                }
            ]
        ),
        new SimpleSkill(
            "Bracing Stance",
            new OnRivalsTurn(),
            [
                new Effect {
                    difference = new Stats<int> {
                        Def = 6,
                        Res = 6
                    }
                },
                new Effect {
                    percentDamageReduction = 10,
                    scope = Scope.FOLLOW_UP
                }
            ]
        ),
        new CloseDef(),
        new DistantDef(),
        new SimplePenalty(
            "Lull Atk/Def",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Def = -3,
                    Atk = -3,
                },
                neutralizedBonus = new Stats<bool> {
                    Def = true,
                    Atk = true,
                }
            }
        ),
        new SimplePenalty(
            "Lull Atk/Res",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Res = -3,
                    Atk = -3
                },
                neutralizedBonus = new Stats<bool> {
                    Res = true,
                    Atk = true
                }
            }
        ),new SimplePenalty(
            "Lull Atk/Spd",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Spd = -3,
                    Atk = -3,
                },
                neutralizedBonus = new Stats<bool> {
                    Spd = true,
                    Atk = true
                }
            }
        ),new SimplePenalty(
            "Lull Def/Res",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Def = -3,
                    Res = -3,
                },
                neutralizedBonus = new Stats<bool> {
                    Def = true,
                    Res = true,
                }
            }
        ),new SimplePenalty(
            "Lull Spd/Def",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Def = -3,
                    Spd = -3
                },
                neutralizedBonus = new Stats<bool> {
                    Spd = true,
                    Def = true
                }
            }
        ),new SimplePenalty(
            "Lull Spd/Res",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Spd = -3,
                    Res = -3
                },
                neutralizedBonus = new Stats<bool> {
                    Spd = true,
                    Res = true
                }
            }
        ),
        new SimplePenalty(
            "Beorc's Blessing",
            new Always(),
            new Effect {
                neutralizedBonus = Stats<bool>.All(),
            }
        ),
        new SimplePenalty(
            "Charmer",
            new OnRivalIsLatestOpponent(),
            new Effect {
                difference = new Stats<int> {
                    Atk = -3,
                    Spd = -3,
                }
            }
         ),
        new LightAndDark(),
        new SimpleSkill(
            "Agnea's Arrow",
            new Always(),
            new Effect {
                    neutralizedPenalty = Stats<bool>.All(),
                }
        ),
        new Dragonskin(),

        new SimpleSkill(
            "Sword Power",
            new OnPlayerWeapon(Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),
        new SimpleSkill(
            "Sword Agility",
            new OnPlayerWeapon(Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),

        new SimpleSkill(
            "Sword Focus",
            new OnPlayerWeapon(Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Res = -10,
                        Atk = 10,
                    }
                }
        ),
        new SimpleSkill(
            "Sturdy Blow",
            new OnPlayersTurn(),
            new Effect {
                    difference = new Stats<int> {
                        Atk = 6,
                        Def = 6,
                    }
                }
        ),
        new SimpleSkill(
            "Still Water",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Atk = 6,
                        Res = 6,
                        Def = -5
                    }
                }
        ),
        new SimpleSkill(
            "Speed +5",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 5,
                    }
                }
        ),
        new SimpleSkill(
            "Spd/Res +5",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 5,
                        Res = 5,
                    }
                }
        ),
        new SimpleSkill(
            "Resistance +5",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Res = 5
                    }
                }
        ),
        new SimpleSkill(
            "Perceptive",
            new OnPlayersTurn(),
            (game, player) => [new Effect {
                difference = new Stats<int> {
                    Spd = 12 + game.Fighter(player).Get(Stat.Spd) / 4,
                }
            }]
        ),
        new SimpleSkill(
            "Solid Ground",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Res = -5,
                        Atk = +6,
                        Def = +6,
                    }
                }
        ),
        new SimpleSkill(
            "Life and Death",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Atk = 6,
                        Spd = 6,
                        Def = -5,
                        Res = -5
                    }
                }
        ),
        new SimpleSkill(
            "Lance Power",
            new OnPlayerWeapon(Weapon.Lance),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),
        new SimpleSkill(
            "Lance Agility",
            new OnPlayerWeapon(Weapon.Lance),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),
        new SimpleSkill(
            "Golden Lotus",
            new OnRivalWeapon(Weapon.Magic).Not(),
            new Effect {
                    percentDamageReduction = 50,
                    scope = Scope.FIRST_ATTACK
                }
        ),
        new SimpleSkill(
            "Fort. Def/Res",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Atk = -2,
                        Def = 6,
                        Res = 6
                    }
                }
        ),

        new SimpleSkill(
            "Defense +5",
            new Always(),
            new Effect {
                    difference = new Stats<int> {
                        Def = 5
                    }
                }
        ),
        new SimpleSkill(
            "Deadly Blade",
            new OnPlayerWeapon(Weapon.Sword).And(new OnPlayersTurn()),
            new Effect {
                    difference = new Stats<int> {
                        Atk = 8,
                        Spd = 8
                    }
                }
        ),
        new SimpleSkill(
            "Axe Power",
            new OnPlayerWeapon(Weapon.Axe),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),

        new SimpleSkill(
            "Bow Agility",
            new OnPlayerWeapon(Weapon.Bow),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),

        new SimpleSkill(
            "Bow Focus",
            new OnPlayerWeapon(Weapon.Bow),
            new Effect {
                    difference = new Stats<int> {
                        Res = -10,
                        Atk = 10
                    }
                }
        ),
        new SimpleSkill(
            "Single-Minded",
            new OnRivalIsLatestOpponent(),
            new Effect {
                difference = new Stats<int> {
                    Atk = 8,
                }
            }
        ),
        new SimpleSkill(
            "Blue Skies",
            new Always(),
            new Effect {
                absoluteDamageReduction = 5,
                extraDamage = 5
            }
        ),
        new SimpleSkill(
            "Dodge",
            new OnGreaterPlayerStat(Stat.Spd),
            (game, player) => {
                var unitSpd = game.Fighter(player).Get(Stat.Spd);
                var rivalSpd = game.Fighter(player + 1).Get(Stat.Spd);
                var percentage = 4 * (unitSpd - rivalSpd);
                return new Effect {
                    percentDamageReduction = Math.Min(percentage, 40),
                };
            }
        ),
        new SimpleSkill(
            "Dragon Wall",
            new OnGreaterPlayerStat(Stat.Res),
            (game, player) => {
                var unitStat = game.Fighter(player).Get(Stat.Res);
                var rivalStat = game.Fighter(player + 1).Get(Stat.Res);
                var percentage = 4 * (unitStat - rivalStat);
                return new Effect {
                        percentDamageReduction = Math.Min(percentage, 40),
                };
            }
        ),
        new SimpleSkill(
            "Wrath",
            new Always(),
            (game, player) => {
                var damage = Math.Min(game.Fighter(player).GetAccumulatedDamage(), 30);
                return new Effect {
                    difference = new Stats<int> {
                        Atk = damage,
                        Spd = damage,
                    }
                };
            }
        ),
        new SimplePenalty(
            "Soulblade",
            new OnPlayerWeapon(Weapon.Sword),
            (game, player) => {
                var rival = game.Fighter(player+1);
                var def = rival.GetBaseStat(Stat.Def);
                var res = rival.GetBaseStat(Stat.Res);
                var z = (def + res)/2;
                return new Effect {
                    difference = new Stats<int> {
                        Def = z - def, Res = z - res
                    }
                };
            }
        ),
        new SimpleSkill(
            "Chivalry",
            new OnPlayersTurn().And(new OnHighRivalHP(100)),
            new Effect {
                extraDamage = 2,
                absoluteDamageReduction = 2,
            }
        ),
        new SimpleSkill(
            "Aegis Shield",
            new Always(),
            [
                new Effect {
                    difference = new Stats<int> {
                        Def = 6,
                        Res = 3,
                    },
                },
                new Effect {
                    percentDamageReduction = 50,
                    scope = Scope.FIRST_ATTACK,
                }
            ]
        ),
        new SimpleSkill(
            "Bushido",
            new Always(),
            (game, player) => {
                var unit = game.Fighter(player);
                var rival = game.Fighter(player);
                var difference = Math.Max(unit.Get(Stat.Spd) - rival.Get(Stat.Spd), 0);
                return new Effect {
                    extraDamage = 7,
                    percentDamageReduction = Math.Min(difference * 4, 40),
                };
            }
        ),
        new DragonsWrath(),
        new SimpleSkill(
            "Ignis",
            new Always(),
            (game, player) =>
                new Effect {
                    difference = new Stats<int> {Atk = game.Fighter(player).Get(Stat.Atk)/2 },
                    scope = Scope.FIRST_ATTACK
                }
        ),
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
        new SimpleSkill(
            "Will to win",
            new OnPlayerLowHP(50),
            new Effect { difference = new Stats<int> { Atk = 8 } }
        ),

        new SimpleSkill(
            "Tome Precision",
            new OnPlayerWeapon(Weapon.Magic),
            new Effect { difference = new Stats<int> { Atk = 6, Spd = 6 } }
        ),

        new SimpleSkill(
            "Death Blow",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Atk = 8 } }
        ),

        new SimpleSkill(
            "Darting Blow",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Spd = 8 } }
        ),
        new SimpleSkill(
            "Warding Blow",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Res = 8 } }
        ),
        new SimpleSkill(
            "Mirror Strike",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Atk = 6, Res = 6 } }
        ),
        new SimpleSkill(
            "Steady Blow",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Spd = 6, Def = 6 } }
        ),
        new SimpleSkill(
            "Swift Strike",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Spd = 6, Res = 6 } }
        ),
        new SimpleSkill(
            "Fire Boost",
            new OnHigherPlayerHP(2),
            new Effect { difference = new Stats<int> { Atk = 6 } }
        ),
        new SimpleSkill(
            "Wind Boost",
            new OnHigherPlayerHP(2),
            new Effect { difference = new Stats<int> { Spd = 6 } }
        ),
        new SimpleSkill(
            "Earth Boost",
            new OnHigherPlayerHP(2),
            new Effect { difference = new Stats<int> { Def = 6 } }
        ),
        new SimpleSkill(
            "Water Boost",
            new OnHigherPlayerHP(2),
            new Effect { difference = new Stats<int> { Res = 6 } }
        ),
        // new SimpleSkill(
        //     "Chaos Style",
        //     (new Not(new OnPlayerWeapon(Weapon.Magic)).And(new OnRivalWeapon(Weapon.Magic))).Or(
        //         new OnPlayerWeapon(Weapon.Magic).And(new Not(new OnRivalWeapon(Weapon.Magic)))
        //     ),
        //     new Effect { difference = new Stats<int> { Spd = 3 } }
        // ),
        new SimpleSkill(
            "Chaos Style",
            new OnPlayerWeapon(Weapon.Magic).Not().And(new OnRivalWeapon(Weapon.Magic)),
            new Effect { difference = new Stats<int> { Spd = 3 } }
        ),

        new SimplePenalty(
            "Blinding Flash",
            new OnPlayersTurn(),
            new Effect { difference = new Stats<int> { Spd = -4 } }
        ),

        new SimplePenalty(
            "Not *Quite*",
            new OnRivalsTurn(),
            new Effect { difference = new Stats<int> { Atk = -4 } }
        ),

        new SimplePenalty(
            "Stunning Smile",
            new OnMaleRival(),
            new Effect { difference = new Stats<int> { Spd = -8 } }
        ),
        new SimplePenalty(
            "Luna", new Always(),
            (game, player) => {
                var def = game.Fighter(1+player).GetBaseStat(Stat.Def) / 2;
                var res = game.Fighter(1+player).GetBaseStat(Stat.Res) / 2;
                return new Effect {
                    difference = new Stats<int> { Def = -def, Res = -res },
                    scope = Scope.FIRST_ATTACK
                };
            }
        ),
        new SimplePenalty(
            "Belief in Love",
            new OnHighRivalHP(100).Or(new OnRivalsTurn()),
            new Effect { difference = new Stats<int> { Atk = -5, Def = -5 } }
        ),
        new SimplePenalty(
            "Disarming Sight",
            new OnMaleRival(),
            new Effect { difference = new Stats<int> { Atk = -8 } }
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
