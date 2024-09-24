


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
        return character.Atk + effects.Select((e) => e.Atk).Sum();
    }

    public int Spd() {
        return character.Spd + effects.Select((e) => e.Spd).Sum();
    }

    public int Def() {
        return character.Def + effects.Select((e) => e.Def).Sum(); ;
    }

    public int Res() {
        return character.Res + effects.Select((e) => e.Res).Sum(); ;
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

}

