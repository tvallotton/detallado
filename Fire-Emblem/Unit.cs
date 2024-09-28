


using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Unit {
    private Character character;

    private int _accDamage;
    List<Effect> effects;

    public List<Skill> skills;

    public Unit(string name, IEnumerable<string> skills) {
        character = Utils.GetCharacterByName(name);
        this.skills = skills.Select(skill => new Skill(skill)).ToList();
        effects = new List<Effect>();

    }

    public override string ToString() {
        return character.Name;
    }


    public bool IsAlive() {
        return 0 < HP();
    }

    public int Attack(Unit rival) {
        int damage = Damage(this, rival);
        rival.TakeDamage(damage);
        return damage;
    }

    public void TakeDamage(int damage) {
        _accDamage += damage;
    }



    public static int Damage(Unit attacker, Unit defender) {
        int attack = (int)(attacker.Atk() * WTB(attacker, defender));
        int defense = Defense(attacker, defender);
        return Math.Max(attack - defense, 0);
    }

    static double WTB(Unit attacker, Unit defender) {
        return attacker.Weapon().WTB(defender.Weapon());
    }

    static int Defense(Unit attacker, Unit defender) {
        if (attacker.Weapon() == global::Weapon.Magic) {
            return defender.Res();
        }
        return defender.Def();
    }

    public bool HasAdvantageOver(Unit rival) {
        return this.Weapon().HasAdvantageOver(rival.Weapon());
    }

    public string Name() {
        return character.Name;
    }

    public Weapon Weapon() {
        return character.Weapon;
    }

    public string Gender() {
        return character.Gender;
    }

    public string DeathQuote() {
        return character.DeathQuote;
    }

    public int HP() {
        return Math.Max(character.HP - _accDamage, 0);
    }

    public int PercentageHP() {
        return 100 * HP() / character.HP;
    }

    public int Atk() {
        return character.Atk + BonusFor("Atk") + PenaltyFor("Atk");
    }

    public int Spd() {
        return character.Spd + BonusFor("Spd") + PenaltyFor("Spd");
    }

    public int Def() {
        return character.Def + BonusFor("Def") + PenaltyFor("Def");
    }

    public int Res() {
        return character.Res + BonusFor("Res") + PenaltyFor("Res");
    }

    int BonusFor(string stat) {
        if (IsBonusNeutralized(stat)) {
            return 0;
        }
        return AllBonuses()
            .Where((x) => x.Item1 == stat)
            .First()
            .Item2;
    }
    int PenaltyFor(string stat) {
        if (IsPenaltyNeutralized(stat)) {
            return 0;
        }
        return AllPenalties()
            .Where((x) => x.Item1 == stat)
            .First()
            .Item2;
    }

    bool IsBonusNeutralized(string stat) {
        return NeutralizedBonuses()
            .Where((t) => t.Item1 == stat)
            .First()
            .Item2;
    }
    bool IsPenaltyNeutralized(string stat) {
        return NeutralizedPenalties()
            .Where((t) => t.Item1 == stat)
            .First()
            .Item2;
    }



    public void ClearEffects() {
        effects.Clear();
    }

    public bool IsValid() {
        return (skills.Count() < 3) && AreSkillsDistinct();
    }

    bool AreSkillsDistinct() {
        var skillNames = skills.Select(skill => skill.Name());
        return skillNames.Count() == skillNames.Distinct().Count();
    }

    public void AddEffect(Effect effect) {
        effects.Add(effect);
    }

    public IEnumerable<string> AnounceBonus() {
        foreach (var (name, value) in AllBonuses()) {
            Trace.Assert(value >= 0);
            if (value != 0) {
                yield return $"{this} obtiene {name}{value.ToString("+#;-#;0")}";
            }
        }
    }

    public IEnumerable<string> AnouncePenalty() {
        foreach (var (name, value) in AllPenalties()) {
            Trace.Assert(value <= 0);
            if (value != 0) {
                yield return $"{this} obtiene {name}{value.ToString("+#;-#;0")}";
            }
        }
    }

    public IEnumerable<string> AnounceNeutralizedBonuses() {
        foreach (var (name, value) in NeutralizedBonuses()) {
            Console.WriteLine($"Los bonus de {name} de {this} fueron neutralizados: {value}");
            if (value) {
                yield return $"Los bonus de {name} de {this} fueron neutralizados";
            }
        }
    }

    public IEnumerable<string> AnounceNeutralizedPenalties() {
        foreach (var (name, value) in NeutralizedPenalties()) {
            if (value) {
                yield return $"Los penalty de {name} de {this} fueron neutralizados";
            }
        }
    }


    IEnumerable<Tuple<string, int>> AllBonuses() {
        foreach (var (name, iter) in Stats()) {
            var bonus = iter.Where(v => v > 0).Sum();
            yield return new Tuple<string, int>(name, bonus);
        }
    }

    IEnumerable<Tuple<string, int>> AllPenalties() {
        foreach (var (name, iter) in Stats()) {
            var bonus = iter.Where(v => v < 0).Sum();
            yield return new Tuple<string, int>(name, bonus);
        }
    }

    (string, IEnumerable<int>)[] Stats() {
        (string, IEnumerable<int>)[] stats = [
            ("Atk", effects.Select((e) => e.diff.Atk)),
            ("Spd", effects.Select((e) => e.diff.Spd)),
            ("Def", effects.Select((e) => e.diff.Def)),
            ("Res", effects.Select((e) => e.diff.Res))
        ];
        return stats;
    }

    (string, bool)[] NeutralizedBonuses() {
        effects.ForEach((x) => {
            Console.WriteLine($"{x.neutralize.bonus.Atk} {x.neutralize.bonus.Spd}");
        });
        (string, bool)[] stats = [
            ("Atk", effects.Any((e) => e.neutralize.bonus.Atk)),
            ("Spd", effects.Any((e) => e.neutralize.bonus.Spd)),
            ("Def", effects.Any((e) => e.neutralize.bonus.Def)),
            ("Res", effects.Any((e) => e.neutralize.bonus.Res)),
        ];
        return stats;
    }


    (string, bool)[] NeutralizedPenalties() {
        (string, bool)[] stats = [
            ("Atk", effects.Any((e) => e.neutralize.penalty.Atk)),
            ("Spd", effects.Any((e) => e.neutralize.penalty.Spd)),
            ("Def", effects.Any((e) => e.neutralize.penalty.Def)),
            ("Res", effects.Any((e) => e.neutralize.penalty.Res))
        ];
        return stats;
    }


}

