


using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Unit {
    private CharacterDto _character;

    private int _accumulatedDamage;

    private List<Effect> _effects;

    private List<Skill> _skills;

    public Unit(string name, IEnumerable<string> skills) {
        _character = Utils.GetCharacterByName(name);
        _skills = skills.Select(skill => new Skill(skill)).ToList();
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

    private void TakeDamage(int damage) {
        _accumulatedDamage += damage;
    }


    private static int Damage(Unit attacker, Unit defender) {
        int attack = (int)(attacker.Get(Stat.Atk) * GetWTB(attacker, defender));
        int defense = GetDefense(attacker, defender);
        return Math.Max(attack - defense, 0);
    }

    private static double GetWTB(Unit attacker, Unit defender) {
        return attacker.GetWeapon().WTB(defender.GetWeapon());
    }

    private static int GetDefense(Unit attacker, Unit defender) {
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
            GetTotalEffectFor(stat, EffectType.Bonus) +
            GetTotalEffectFor(stat, EffectType.Penalty)
        );
    }

    private int GetTotalEffectFor(Stat stat, EffectType effectType) {
        if (IsNeutralized(stat, effectType))
            return 0;
        return GetEffectFor(stat, effectType);
    }

    public int GetEffectFor(Stat stat, EffectType effectType) {
        return _effects
             .Select(effect => effect.difference.Get(stat))
             .Where(value => value != 0)
             .Where(value => value > 0 ^ effectType == EffectType.Penalty)
             .Sum();
    }

    public bool IsNeutralized(Stat stat, EffectType effectType) {
        return _effects.Any(e => e.GetNeutralized(effectType).Get(stat));
    }

    public void ClearEffects() {
        _effects.Clear();
    }

    public bool IsValid() {
        return (_skills.Count() < 3) && AreSkillsDistinct();
    }

    bool AreSkillsDistinct() {
        var skillNames = _skills.Select(skill => skill.Name());
        return skillNames.Count() == skillNames.Distinct().Count();
    }

    public void AddEffect(Effect effect) {
        _effects.Add(effect);
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

    public IEnumerable<Skill> GetSkills() {
        return _skills;
    }
}

