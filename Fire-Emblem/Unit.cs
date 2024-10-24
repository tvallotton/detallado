


using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Unit {
    private CharacterDto _character;

    private int _accumulatedDamage;

    private List<Effect> _effects;

    public List<Skill> skills;

    public Unit(string name, IEnumerable<string> skills) {
        _character = Utils.GetCharacterByName(name);
        this.skills = skills.Select(skill => new Skill(skill)).ToList();
        _effects = new List<Effect>();

    }

    public override string ToString() {
        return _character.Name;
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
        _accumulatedDamage += damage;
    }


    public static int Damage(Unit attacker, Unit defender) {
        int attack = (int)(attacker.Get(Stat.Atk) * GetWTB(attacker, defender));
        int defense = GetDefense(attacker, defender);
        return Math.Max(attack - defense, 0);
    }

    static double GetWTB(Unit attacker, Unit defender) {
        return attacker.GetWeapon().WTB(defender.GetWeapon());
    }

    static int GetDefense(Unit attacker, Unit defender) {
        if (attacker.GetWeapon() == global::Weapon.Magic) {
            return defender.Get(Stat.Res);
        }
        return defender.Get(Stat.Def);
    }

    public bool HasAdvantageOver(Unit rival) {
        return this.GetWeapon().HasAdvantageOver(rival.GetWeapon());
    }

    public string GetName() {
        return _character.Name;
    }

    public Weapon GetWeapon() {
        return _character.Weapon;
    }


    public int HP() {
        return Math.Max(_character.HP - _accumulatedDamage, 0);
    }

    public int PercentageHP() {
        return 100 * HP() / _character.HP;
    }

    public int Get(Stat stat) {
        return (
            GetBaseStat(stat) +
            GetEffectFor(stat, EffectType.Bonus) +
            GetEffectFor(stat, EffectType.Penalty)
        );
    }

    private int GetEffectFor(Stat stat, EffectType effectType) {
        if (IsNeutralized(stat, effectType)) {
            return 0;
        }
        return _effects
             .Select(effect => effect.difference.Get(stat))
             .Where(value => value > 0 ^ effectType == EffectType.Penalty)
             .Sum();
    }

    bool IsNeutralized(Stat stat, EffectType effectType) {
        return _effects.Any(e => e.GetNeutralized(effectType).Get(stat));
    }

    public void ClearEffects() {
        _effects.Clear();
    }

    public bool IsValid() {
        return (skills.Count() < 3) && AreSkillsDistinct();
    }

    bool AreSkillsDistinct() {
        var skillNames = skills.Select(skill => skill.Name());
        return skillNames.Count() == skillNames.Distinct().Count();
    }

    public void AddEffect(Effect effect) {
        _effects.Add(effect);
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



    IEnumerable<Tuple<Stat, int>> AllBonuses() {
        foreach (var (name, iter) in Stats()) {
            var bonus = iter.Where(v => v > 0).Sum();
            yield return new Tuple<Stat, int>(name, bonus);
        }
    }

    IEnumerable<Tuple<Stat, int>> AllPenalties() {
        foreach (var (name, iter) in Stats()) {
            var bonus = iter.Where(v => v < 0).Sum();
            yield return new Tuple<Stat, int>(name, bonus);
        }
    }

    (Stat, IEnumerable<int>)[] Stats() {
        (Stat, IEnumerable<int>)[] stats = [
            (Stat.Atk, _effects.Select((e) => e.difference.Atk)),
            (Stat.Spd, _effects.Select((e) => e.difference.Spd)),
            (Stat.Def, _effects.Select((e) => e.difference.Def)),
            (Stat.Res, _effects.Select((e) => e.difference.Res))
        ];
        return stats;
    }

    (Stat, bool)[] NeutralizedBonuses() {
        _effects.ForEach((x) => {
            Console.WriteLine($"{x.neutralizedBonus.Atk} {x.neutralizedBonus.Spd}");
        });
        (Stat, bool)[] stats = [
            (Stat.Atk, _effects.Any((e) => e.neutralizedBonus.Atk)),
            (Stat.Spd, _effects.Any((e) => e.neutralizedBonus.Spd)),
            (Stat.Def, _effects.Any((e) => e.neutralizedBonus.Def)),
            (Stat.Res, _effects.Any((e) => e.neutralizedBonus.Res)),
        ];
        return stats;
    }


    (Stat, bool)[] NeutralizedPenalties() {
        (Stat, bool)[] stats = [
            (Stat.Atk, _effects.Any((e) => e.neutralizedPenalty.Atk)),
            (Stat.Spd, _effects.Any((e) => e.neutralizedPenalty.Spd)),
            (Stat.Def, _effects.Any((e) => e.neutralizedPenalty.Def)),
            (Stat.Res, _effects.Any((e) => e.neutralizedPenalty.Res))
        ];
        return stats;
    }

    public int GetBaseStat(Stat stat) {
        switch (stat) {
            case Stat.Atk: return _character.Atk;
            case Stat.Spd: return _character.Spd;
            case Stat.Def: return _character.Def;
            case Stat.Res: return _character.Res;
        }
        throw new UnreachableException();
    }


}

