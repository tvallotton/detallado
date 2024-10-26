


using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Unit {
    private Character _character;

    private int _accumulatedDamage;

    private List<Effect> _effects;

    private List<Skill> _skills;

    private Unit _latestOpponent;

    public Unit(string name, IEnumerable<string> skills) {
        _character = Utils.GetCharacterByName(name);
        _skills = skills.Select(skill => new Skill(skill)).ToList();
        _effects = new List<Effect>();
    }

    public override string ToString() {
        return _character.Name;
    }


    public bool IsAlive() {
        return 0 < GetHP();
    }

    public int Attack(Unit rival, Scope scope) {
        int damage = ComputeDamage(this, rival, scope);
        rival.TakeDamage(damage);
        return damage;
    }

    private void TakeDamage(int damage) {
        _accumulatedDamage += damage;
    }


    private static int ComputeDamage(Unit attacker, Unit defender, Scope scope) {
        var defenderEffects = defender.GetEffectsByScope(scope).ToList();
        var attackerEffects = attacker.GetEffectsByScope(scope);
        int damage = ComputeBaseDamage(attacker, defender, scope);
        damage += attacker.GetExtraDamage(attackerEffects);
        damage = defender.ReduceDamagePercentwise(damage, defenderEffects);
        damage -= defender.GetDamageReduction(defenderEffects);
        return Math.Max(damage, 0);
    }

    private static int ComputeBaseDamage(Unit attacker, Unit defender, Scope scope) {
        int attack = (int)(attacker.Get(Stat.Atk, scope) * GetWTB(attacker, defender));
        int defense = GetDefense(attacker, defender, scope);
        return Math.Max(attack - defense, 0);
    }

    private static double GetWTB(Unit attacker, Unit defender) {
        return attacker.GetWeapon().WTB(defender.GetWeapon());
    }

    private static int GetDefense(Unit attacker, Unit defender, Scope scope) {
        if (attacker.GetWeapon() == global::Weapon.Magic) {
            return defender.Get(Stat.Res, scope);
        }
        return defender.Get(Stat.Def, scope);
    }
    public string GetGender() {
        return _character.Gender;
    }

    public bool HasAdvantageOver(Unit rival) {
        return GetWeapon().HasAdvantageOver(rival.GetWeapon());
    }

    public string GetName() {
        return _character.Name;
    }

    public Weapon GetWeapon() {
        return _character.Weapon;
    }


    public int GetHP() {
        return Math.Max(_character.HP - _accumulatedDamage, 0);
    }

    public int GetAccumulatedDamage() {
        return _accumulatedDamage;
    }

    public int GetPercentageHP() {
        return 100 * GetHP() / _character.HP;
    }

    public int GetTotalPercentDamageReduction(Scope scope) {
        return 100 - ReduceDamagePercentwise(100, GetEffectByScopeExact(scope));
    }

    public int GetExtraDamage(Scope scope) {
        return GetExtraDamage(GetEffectByScopeExact(scope));
    }
    public int GetAbsoluteDamageReduction(Scope scope) {
        return GetDamageReduction(GetEffectByScopeExact(scope));
    }

    public int Get(Stat stat) {
        return Get(stat, Scope.ALL);
    }

    public int Get(Stat stat, Scope scope) {
        return (
            GetBaseStat(stat) +
            GetTotalEffectFor(stat, EffectType.Bonus, scope) +
            GetTotalEffectFor(stat, EffectType.Penalty, scope)
        );
    }

    private int GetTotalEffectFor(Stat stat, EffectType effectType, Scope scope) {
        if (IsNeutralized(stat, effectType))
            return 0;
        return GetEffectFor(stat, effectType, (effect) => effect.scope.Includes(scope));
    }

    public int GetEffectFor(Stat stat, EffectType effectType, Func<Effect, bool> filter) {
        return _effects
             .Where(filter)
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

    public void SetLatestOpponent(Unit opponent) {
        _latestOpponent = opponent;
    }

    public bool IsLatestOpponent(Unit opponent) {
        return _latestOpponent == opponent;
    }

    public bool IsValid() {
        return (_skills.Count() < 3) && AreSkillsDistinct();
    }

    private bool AreSkillsDistinct() {
        var skillNames = _skills.Select(skill => skill.Name());
        return skillNames.Count() == skillNames.Distinct().Count();
    }

    public void AddEffect(Effect effect) {
        _effects.Add(effect);
    }


    public IEnumerable<Skill> GetSkills() {
        return _skills;
    }

    private int ReduceDamagePercentwise(int initialDamage, IEnumerable<Effect> effects) {
        double damage = initialDamage;
        foreach (var effect in effects) {
            damage = damage * (100.0 - effect.percentDamageReduction) / 100.0;
            damage = Math.Round(damage, 9);
        }
        return Convert.ToInt32(Math.Floor(damage));
    }

    private int GetExtraDamage(IEnumerable<Effect> effects) {
        return effects.Select(e => e.extraDamage).Sum();
    }

    private int GetDamageReduction(IEnumerable<Effect> effects) {
        return effects.Select(e => e.absoluteDamageReduction).Sum();
    }

    private IEnumerable<Effect> GetEffectsByScope(Scope scope) {
        return _effects.Where(effect => effect.scope.Includes(scope));
    }

    private IEnumerable<Effect> GetEffectByScopeExact(Scope scope) {
        return _effects.Where(effect => effect.scope == scope);
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

