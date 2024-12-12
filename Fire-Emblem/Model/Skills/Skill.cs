


using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using Fire_Emblem;

public class Skill {
    private string _name;
    IEnumerable<BaseSkill> skills;

    static BaseSkill[] SKILLS = {
        new SimpleSkill(
            "Armored Blow",
            new OnTurn(Subject.Self),
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
            new OnTurn(Subject.Self),
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
            new OnTurn(Subject.Self),
            new Effect {
                    difference = new Stats<int> {
                    Atk = 6,
                    Spd = 6,
                }
            }
        ),

        new SimpleSkill(
            "Darting Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect {
                    difference = new Stats<int> {
                        Spd = 8
                    },
                },
                new Effect {
                    percentagewiseDamageReduction = 10,
                    scope = Scope.FOLLOW_UP,
                }
            ]
        ),
        new SimpleSkill(
            "Bracing Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect {
                    difference = new Stats<int> {
                        Def = 6,
                        Res = 6
                    }
                },
                new Effect {
                    percentagewiseDamageReduction = 10,
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
            new OnWeapon(Subject.Self, Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),
        new SimpleSkill(
            "Sword Agility",
            new OnWeapon(Subject.Self, Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),

        new SimpleSkill(
            "Sword Focus",
            new OnWeapon(Subject.Self, Weapon.Sword),
            new Effect {
                    difference = new Stats<int> {
                        Res = -10,
                        Atk = 10,
                    }
                }
        ),
        new SimpleSkill(
            "Sturdy Blow",
            new OnTurn(Subject.Self),
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
            new OnTurn(Subject.Self),
            (game, player) => [new Effect {
                difference = new Stats<int> {
                    Spd = 12 + game.GetFighter(player).GetBaseStat(Stat.Spd) / 4,
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
            new OnWeapon(Subject.Self, Weapon.Lance),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),
        new SimpleSkill(
            "Lance Agility",
            new OnWeapon(Subject.Self, Weapon.Lance),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),
        new SimpleSkill(
            "Golden Lotus",
            new OnWeapon(Subject.Rival, Weapon.Magic).Not(),
            new Effect {
                    percentagewiseDamageReduction = 50,
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
            new OnWeapon(Subject.Self, Weapon.Sword).And(new OnTurn(Subject.Self)),
            new Effect {
                    difference = new Stats<int> {
                        Atk = 8,
                        Spd = 8
                    }
                }
        ),
        new SimpleSkill(
            "Axe Power",
            new OnWeapon(Subject.Self, Weapon.Axe),
            new Effect {
                    difference = new Stats<int> {
                        Def = -10,
                        Atk = 10
                    }
                }
        ),

        new SimpleSkill(
            "Bow Agility",
            new OnWeapon(Subject.Self, Weapon.Bow),
            new Effect {
                    difference = new Stats<int> {
                        Spd = 12,
                        Atk = -6
                    }
                }
        ),

        new SimpleSkill(
            "Bow Focus",
            new OnWeapon(Subject.Self, Weapon.Bow),
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
            "Wrath",
            new Always(),
            (game, player) => {
                var damage = Math.Min(game.GetFighter(player).GetAccumulatedDamage(), 30);
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
            new OnWeapon(Subject.Self, Weapon.Sword),
            (game, player) => {
                var rival = game.GetFighter(player+1);
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
            new OnTurn(Subject.Self).And(new OnHighPercentageHP(Subject.Rival, hp: 100)),
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
                    percentagewiseDamageReduction = 50,
                    scope = Scope.FIRST_ATTACK,
                }
            ]
        ),
        new DiffStatX4DamageReduction("Bushido", Stat.Spd),
        new SimpleSkill(
            "Bushido",
            new Always(),
            new Effect { extraDamage = 7 }
        ),
        new DragonsWrath(),
        new SimpleSkill(
            "Ignis",
            new Always(),
            (game, player) =>
                new Effect {
                    difference = new Stats<int> {Atk = game.GetFighter(player).GetBaseStat(Stat.Atk)/2 },
                    scope = Scope.FIRST_ATTACK
                }
        ),
        new SimpleSkill(
            "Remote Mirror",
            new OnTurn(Subject.Self),
            [
                new Effect { difference = new Stats<int> {Atk = 7, Res = 10} },
                new Effect { percentagewiseDamageReduction = 30, scope = Scope.FIRST_ATTACK }
            ]
        ),
        new SimpleSkill(
            "Magic Guard",
            new OnWeapon(Subject.Rival, Weapon.Magic),
            [new Effect { absoluteDamageReduction = 5, }]
        ),
        new SimpleSkill(
            "Lance Guard",
            new OnWeapon(Subject.Rival, Weapon.Lance),
            [new Effect { absoluteDamageReduction = 5, }]
        ),
        new SimpleSkill(
            "Axe Guard",
            new OnWeapon(Subject.Rival, Weapon.Axe),
            [new Effect { absoluteDamageReduction = 5, }]
        ),

        new SimpleSkill(
            "Bow Guard",
            new OnWeapon(Subject.Rival, Weapon.Bow),
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
            "Bravery",
            new Always(),
            [new Effect { extraDamage = 5 }]
        ),

         new SimpleSkill(
            "Swift Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Spd = 6, Res=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Steady Posture",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Spd = 6, Def=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Mirror Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Res=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Sturdy Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Def=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Kestrel Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Atk = 6, Spd=6} },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),

        new SimpleSkill(
            "Warding Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Res = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),


        new SimpleSkill(
            "Steady Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Def = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Fierce Stance",
            new OnTurn(Subject.Rival),
            [
                new Effect { difference = new Stats<int> { Atk = 8 } },
                new Effect { scope =Scope.FOLLOW_UP , percentagewiseDamageReduction=10 },
            ]
        ),
        new SimpleSkill(
            "Remote Sturdy",
            new OnTurn(Subject.Self),
            [
                new Effect { difference = new Stats<int> { Atk = 7, Def= 10 } },
                new Effect { scope =Scope.FIRST_ATTACK , percentagewiseDamageReduction=30 },
            ]
        ),
        new SimpleSkill(
            "Remote Sparrow",
            new OnTurn(Subject.Self),
            [
                new Effect { difference = new Stats<int> { Atk = 7, Spd= 7 } },
                new Effect { scope =Scope.FIRST_ATTACK , percentagewiseDamageReduction=30 },
            ]
        ),
        new SimpleSkill(
            "Will to Win",
            new OnPlayerLowHP(50),
            new Effect { difference = new Stats<int> { Atk = 8 } }
        ),

        new SimpleSkill(
            "Tome Precision",
            new OnWeapon(Subject.Self, Weapon.Magic),
            new Effect { difference = new Stats<int> { Atk = 6, Spd = 6 } }
        ),

        new SimpleSkill(
            "Death Blow",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Atk = 8 } }
        ),

        new SimpleSkill(
            "Darting Blow",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Spd = 8 } }
        ),
        new SimpleSkill(
            "Warding Blow",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Res = 8 } }
        ),
        new SimpleSkill(
            "Mirror Strike",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Atk = 6, Res = 6 } }
        ),
        new SimpleSkill(
            "Steady Blow",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Spd = 6, Def = 6 } }
        ),
        new SimpleSkill(
            "Swift Strike",
            new OnTurn(Subject.Self),
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
        new SimpleSkill(
            "Chaos Style",
            new OnTurn(Subject.Self).And(
                new OnWeapon(Subject.Self, Weapon.Magic).And(new Not(new OnWeapon(Subject.Rival, Weapon.Magic)))
                    .Or(new Not(new OnWeapon(Subject.Self, Weapon.Magic)).And(new OnWeapon(Subject.Rival, Weapon.Magic)))
            ),
            new Effect { difference = new Stats<int> { Spd = 3 } }
        ),

        new SimplePenalty(
            "Blinding Flash",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> { Spd = -4 } }
        ),

        new SimplePenalty(
            "Not *Quite*",
            new OnTurn(Subject.Rival),
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
                var def = game.GetFighter(1+player).GetBaseStat(Stat.Def) / 2;
                var res = game.GetFighter(1+player).GetBaseStat(Stat.Res) / 2;
                return new Effect {
                    difference = new Stats<int> { Def = -def, Res = -res },
                    scope = Scope.FIRST_ATTACK
                };
            }
        ),
        new SimplePenalty(
            "Belief in Love",
            new OnHighPercentageHP(Subject.Rival, 100).Or(new OnTurn(Subject.Rival)),
            new Effect { difference = new Stats<int> { Atk = -5, Def = -5 } }
        ),
        new SimplePenalty(
            "Disarming Sigh",
            new OnMaleRival(),
            new Effect { difference = new Stats<int> { Atk = -8 } }
        ),
        new SimpleSkill(
            "Sandstorm",
            new Always(),
            (game, player) => {
                var unit = game.GetFighter(player);
                return new Effect {
                    difference = new Stats<int> {
                        Atk = unit.GetBaseStat(Stat.Def) * 3/2 - unit.GetBaseStat(Stat.Atk),
                    },
                    scope = Scope.FOLLOW_UP
                };
            }
        ),
        new SimpleSkill(
            "HP +15",
            new Always(),
            (game, player) => {
                var fighter = game.GetFighter(player);
                if (fighter.GetPercentageHP() == 100)
                    fighter.TakeDamage(-15);
                return [];
            }
        ),
        new SimpleSkill(
            "Arms Shield",
            new OnWeaponAdvantage(),
            new Effect {
                absoluteDamageReduction = 7
            }
        ),
        new SimpleSkill(
            "Back at You",
            new OnTurn(Subject.Rival),
            (game, player) => new Effect {
                extraDamage = game.GetFighter(player).GetAccumulatedDamage() / 2
            }
        ),
        new SimpleSkill(
            "Lunar Brace",
            new OnTurn(Subject.Self).And(new OnWeapon(Subject.Self, Weapon.Magic).Not()),
            (game, player) => new Effect {
                extraDamage = game.GetFighter(1+player).GetBaseStat(Stat.Def)*3/10,
            }
        ),
        new DiffStatX4DamageReduction("Dodge", Stat.Spd),
        new DiffStatX4DamageReduction("Dragon Wall", Stat.Res),
        new DiffStatX4DamageReduction("Moon-Twin Wing", Stat.Spd),
           new SimplePenalty(
            "Moon-Twin Wing",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> { Atk = -5, Spd = -5}
            }
        ),
        new SimplePenalty(
            "Poetic Justice",
            new Always(),
            new Effect {
                difference = new Stats<int> { Spd = -4 }
            }
        ),
        new SimpleSkill(
            "Poetic Justice",
            new Always(),
            (game, player ) => {
                var fighter = game.GetFighter(1+player);
                var atk = fighter.GetBaseStat(Stat.Atk);
                return new Effect { extraDamage = atk*15/100 };
            }
        ),

        new SimpleSkill(
            "Laguz Friend",
            new Always(),
            (game, player) => {
                var fighter = game.GetFighter(player);
                var res = fighter.GetBaseStat(Stat.Res);
                var def = fighter.GetBaseStat(Stat.Def);
                return new Effect {
                    percentagewiseDamageReduction = 50,
                    difference = new Stats<int> {
                        Res = -res/2,
                        Def = -def/2,
                    },
                    neutralizedBonus = new Stats<bool> {
                        Def = true,
                        Res = true,
                    }
                };
            }
        ),
        new SimplePenalty(
            "Prescience",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Atk = -5,
                    Res = -5,
                }
            }
        ),
        new SimpleSkill(
            "Prescience",
            new OnTurn(Subject.Self)
                .Or(new OnWeapon(Subject.Rival, Weapon.Magic))
                .Or(new OnWeapon(Subject.Rival, Weapon.Bow)),
            new Effect {
                percentagewiseDamageReduction = 30,
                scope = Scope.FIRST_ATTACK
            }
        ),
        new SimplePenalty(
            "Guard Bearing",
            new Always(),
            new Effect {
                difference = new Stats<int> {
                    Spd = -4,
                    Def = -4
                }
            }
        ),
        new SimpleSkill(
            "Guard Bearing",
            new OnHighPercentageHP(Subject.Self, 100),
            new Effect {
                percentagewiseDamageReduction = 60,
            }
        ),
        new SimpleSkill(
            "Guard Bearing",
            new Not(new OnHighPercentageHP(Subject.Self, 100)),
            new Effect {
                percentagewiseDamageReduction = 30
            }
        ),
        new SimplePenalty(
            "Extra Chivalry",
            new OnHighPercentageHP(Subject.Rival, 50),
            new Effect {
                difference = new Stats<int> {
                    Atk = -5, Def = -5, Spd = -5
                }
            }
        ),
        new ExtraChivalry(),
        new SimpleSkill(
            "Sol",
            new Always(),
            new Effect { healing = 25 }
        ),
        new SimpleSkill(
            "Nosferatu",
            new OnWeapon(Subject.Self, Weapon.Magic),
            new Effect { healing = 50 }
        ),
        new SimpleSkill(
            "Solar Brace",
            new OnTurn(Subject.Self),
            new Effect { healing = 50 }
        ),
        new SimpleSkill(
            "Windsweep",
            new OnWeapon(Subject.Rival, Weapon.Sword).And(new OnWeapon(Subject.Self, Weapon.Sword)),
            new Effect { counterAttackNegation = 1 }
        ),
        new SimpleSkill(
            "Surprise Attack",
            new OnWeapon(Subject.Rival, Weapon.Bow).And(new OnWeapon(Subject.Self, Weapon.Bow)),
            new Effect { counterAttackNegation = 1 }
        ),
        new SimpleSkill(
            "Hliðskjálf",
            new OnWeapon(Subject.Rival, Weapon.Magic).And(new OnWeapon(Subject.Self, Weapon.Magic)),
            new Effect { counterAttackNegation = 1 }
        ),
        new SimpleSkill(
            "Null C-Disrupt",
            new Always(),
            new Effect { counterAttackNegationBlocker = 1 }
        ),
        new SimpleSkill(
            "Laws of Sacae",
            new OnTurn(Subject.Self),
            new Effect {
                difference = new Stats<int> { Atk = 6, Def = 6, Res = 6, Spd = 6, }
            }
        ),
        new SimpleSkill(
            "Laws of Sacae",
            new OnWeapon(Subject.Self, Weapon.Magic).Or(new OnWeapon(Subject.Self, Weapon.Bow)).Not()
            .And(new OnGreaterPlayerStat(Stat.Spd, 6)),
            new Effect { counterAttackNegation = 1 }
        ),
        new SimplePenalty(
            "Flare",
            new OnWeapon(Subject.Self, Weapon.Magic),
            (game, player ) => {
                var rival = game.GetFighter(player+1);
                return new Effect {
                    difference = new Stats<int> {Res = -rival.GetBaseStat(Stat.Res)/5},
                };
            }
        ),
        new SimpleSkill(
            "Flare",
            new OnWeapon(Subject.Self, Weapon.Magic),
            new Effect{healing = 50,}
        ),

         new SimpleSkill(
            "Eclipse Brace",
            new OnTurn(Subject.Self),
            (game, player) => {
                var rival = game.GetFighter(player + 1);
                return new Effect { healing = 50 };
            }
        ),
          new SimpleSkill(
            "Eclipse Brace",
            new OnTurn(Subject.Self).And(new OnWeapon(Subject.Self, Weapon.Magic).Not()),
            (game, player) => {
                var rival = game.GetFighter(player + 1);
                return new Effect { extraDamage = 3 * rival.GetBaseStat(Stat.Def) / 10 };
            }
        ),
        new SimpleSkill(
            "Resonance",
            new OnWeapon(Subject.Self, Weapon.Magic).And(new OnHighPercentageHP(Subject.Self, 2)),
            new Effect { damageBeforeCombat = 1, extraDamage = 3 }
        ),
        new SimpleSkill(
            "Fury",
            new Always(),
            new Effect {
                difference = new Stats<int> { Atk = 4, Spd = 4,Def = 4,Res = 4 },
                damageAfterCombat = 8
            }
        ),
        new SimpleSkill(
            "Atk/Spd Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Atk = 7, Spd = 7},
            }
        ),
        new SimpleSkill(
            "Atk/Spd Push",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),

        new SimpleSkill(
            "Atk/Def Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Atk = 7, Def = 7},
            }
        ),
        new SimpleSkill(
            "Atk/Def Push",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),
        new SimpleSkill(
            "Atk/Res Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Atk = 7, Res = 7},
            }
        ),
        new SimpleSkill(
            "Atk/Res Push",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),
        new SimpleSkill(
            "Spd/Def Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Spd = 7, Def = 7},
            }
        ),
        new SimpleSkill(
            "Spd/Def Push",
           new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),
        new SimpleSkill(
            "Spd/Res Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Spd = 7, Res = 7},
            }
        ),
        new SimpleSkill(
            "Spd/Res Push",
           new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),
         new SimpleSkill(
            "Def/Res Push",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {Def = 7, Res = 7},
            }
        ),
        new SimpleSkill(
            "Def/Res Push",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnHasAttacked(Subject.Self)),
            new Effect {
                damageAfterCombat = 5
            }
        ),
        new SimpleSkill(
            "Scendscale",
            new OnHasAttacked(Subject.Self),
            new Effect {
                damageAfterCombat = 7
            }
        ),
        new SimpleSkill(
            "Scendscale",
            new Always(),
            (game, player) => {
                var unit = game.GetFighter(player);
                return new Effect {
                    extraDamage = unit.GetBaseStat(Stat.Atk)/4
                };
            }
        ),
        new SimpleSkill(
            "Mastermind",
            new OnHighAbsoluteHP(Subject.Self, 2),
            new Effect {
                damageBeforeCombat = 1,
            }
        ),
        new Mastermind(),
        new SimplePenalty(
            "Mystic Boost",
            new Always(),
            new Effect { difference = new Stats<int> { Atk = -5 } }
        ),
        new SimpleSkill(
            "Mystic Boost",
            new Always(),
            new Effect { afterCombatHealing = 10 }
        ),
        new BewitchingTomeBonus(),
        new BewitchingTomePenalty(),
        new SimpleSkill(
            "Quick Riposte",
            new OnHighPercentageHP(Subject.Self, 60).And(new OnTurn(Subject.Rival)),
            new Effect { followUpGuarantee = 1 }
        ),
        new SimpleSkill(
            "Follow-Up Ring",
            new OnHighPercentageHP(Subject.Self, 50),
            new Effect { followUpGuarantee = 1 }
        ),
        new SimplePenalty(
            "Wary Fighter",
            new OnHighPercentageHP(Subject.Self, 50),
            new Effect { followUpNegation = 1 }
        ),
         new SimpleSkill(
            "Wary Fighter",
            new OnHighPercentageHP(Subject.Self, 50),
            new Effect { followUpNegation = 1 }
        ),
        new SimplePenalty(
            "Piercing Tribute",
            new Always(),
            new Effect { defensiveNullFollowUp = 1 }
        ),
        new SimpleSkill(
            "Mjölnir",
            new Always(),
            new Effect { offensiveNullFollowUp = 1 }
        ),
        new SimpleSkill(
            "Melee Breaker",
            new All(
                new OnHighPercentageHP(Subject.Self, 50),
                new Any(
                    new OnWeapon(Subject.Rival, Weapon.Sword),
                    new OnWeapon(Subject.Rival, Weapon.Lance),
                    new OnWeapon(Subject.Rival, Weapon.Axe)
                )
            ),
            new Effect { followUpGuarantee = 1, followUpNegation = 1 }
        ),
        new SimpleSkill(
            "Range Breaker",
            new All(
                new OnHighPercentageHP(Subject.Self, 50),
                new Any(
                    new OnWeapon(Subject.Rival, Weapon.Magic),
                    new OnWeapon(Subject.Rival, Weapon.Bow)
                )
            ),
            new Effect { followUpGuarantee = 1, followUpNegation = 1 }
        ),
        new SimpleSkill(
            "Null Follow-Up",
            new Always(),
            new Effect { defensiveNullFollowUp = 1, offensiveNullFollowUp = 1 }
        ),
        new SimpleSkill(
            "Sturdy Impact",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> {Atk = 6 , Def = 10}, followUpNegation = 1}
        ),
        new SimpleSkill(
            "Mirror Impact",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> {Atk = 6 , Res = 10}, followUpNegation = 1}
        ),
        new SimpleSkill(
            "Swift Impact",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> {Spd = 6 , Res = 10}, followUpNegation = 1}
        ),
        new SimpleSkill(
            "Steady Impact",
            new OnTurn(Subject.Self),
            new Effect { difference = new Stats<int> {Spd = 6 , Def = 10}, followUpNegation = 1}
        ),
        new SimpleSkill(
            "Slick Fighter",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnTurn(Subject.Rival)),
            new Effect { neutralizedPenalty = Stats<bool>.All(), followUpGuarantee = 1}
        ),
        new SimplePenalty(
            "Wily Fighter",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnTurn(Subject.Rival)),
            new Effect { neutralizedBonus = Stats<bool>.All() }
        ),
        new SimpleSkill(
            "Wily Fighter",
            new OnHighPercentageHP(Subject.Self, 25).And(new OnTurn(Subject.Rival)),
            new Effect { followUpGuarantee = 1}
        ),
        new SimpleSkill(
            "Savvy Fighter",
            new OnTurn(Subject.Rival),
            new Effect { defensiveNullFollowUp = 1 , offensiveNullFollowUp = 1}
        ),
        new SimpleSkill(
            "Savvy Fighter",
            new All(
                new OnTurn(Subject.Rival),
                new OnGreaterPlayerStat(Stat.Spd, 3)
            ),
            new Effect {  percentagewiseDamageReduction = 30, scope = Scope.FIRST_ATTACK }
        ),
        new SimpleSkill(
            "Flow Force",
            new OnTurn(Subject.Self),
            new Effect {
                offensiveNullFollowUp = 1, neutralizedPenalty = new Stats<bool> {
                    Atk = true, Spd = true
                }
            }
        ),
        new SimpleSkill(
            "Flow Refresh",
            new OnTurn(Subject.Self),
            new Effect {
                offensiveNullFollowUp = 1,afterCombatHealing = 10
            }
        ),
        new SimpleSkill(
            "Binding Shield",
            new OnGreaterPlayerStat(Stat.Spd, 4),
            new Effect {
              followUpGuarantee = 1, followUpNegation = 1,counterAttackNegation = 1
            }
        ),
        new SimpleSkill(
            "Sun-Twin Wing",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                defensiveNullFollowUp = 1,
                offensiveNullFollowUp = 1
            }
        ),
        new SimpleSkill(
            "Sun-Twin Wing",
            new OnTurn(Subject.Self),
            new Effect {
            }
        ),
        new SimplePenalty(
            "Sun-Twin Wing",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {
                    Def = -5, Spd = -5
                },
            }
        ),
        new SimplePenalty(
            "Dragon's Ire",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {
                    Atk = -4, Res = -4
                }
            }
        ),
        new SimpleSkill(
            "Dragon's Ire",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                followUpGuarantee = 1,
            }
        ),
        new SimpleSkill(
            "Dragon's Ire",
            new All(new OnHighPercentageHP(Subject.Self, 25), new OnTurn(Subject.Rival)),
            new Effect {
                offensiveNullFollowUp = 1
            }
        ),
        new SimpleSkill(
            "Black Eagle Rule",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect { followUpGuarantee = 1 }
        ),
        new SimpleSkill(
            "Black Eagle Rule",
            new All(new OnHighPercentageHP(Subject.Self, 25), new OnTurn(Subject.Rival)),
            new Effect { percentagewiseDamageReduction = 80, scope = Scope.FOLLOW_UP }
        ),
        new DiffStatX4DamageReduction("Blue Lion Rule", Stat.Def),
        new SimpleSkill(
            "Blue Lion Rule",
            new OnTurn(Subject.Rival),
            new Effect { followUpGuarantee = 1 }
        ),
        new SimplePenalty(
            "New Divinity",
            new OnHighPercentageHP(Subject.Self, 25),
            new Effect {
                difference = new Stats<int> {
                    Atk = -5, Res = -5
                }
            }
        ),
        new DiffStatX4DamageReduction("New Divinity", Stat.Res, new OnHighPercentageHP(Subject.Self, 25)),
        new SimpleSkill(
            "New Divinity",
            new OnHighPercentageHP(Subject.Self, 40),
            new Effect {
               followUpNegation = 1
            }
        ),

};

    public Skill(string name) {
        _name = name;
        skills = SKILLS.Where((skill) => skill.name == name);
    }

    public string Name() {
        return _name;
    }

    public void Register(GameState game, int player, EffectDependency dependency) {
        foreach (var skill in skills)
            skill.Register(game, player, dependency);
    }


}
