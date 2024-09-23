



using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;


class Unit {
    public Character character;

    public List<Skill> skills;

    public Unit(string name, IEnumerable<string> skills) {


        string json = File.ReadAllText("characters.json");
        List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

        Debug.Assert(characters != null);

        Character? character = characters.Find(character => character.Name == name);

        Debug.Assert(character != null);


        this.character = character;
        this.skills = skills.Select(skillName => new Skill(skillName)).ToList();


    }

    public override string ToString() {
        return character.Name;
    }


    public bool IsAlive() {
        return 0 < character.HP;
    }

    public int Attack(Unit rival) {
        int damage = Damage(rival);
        rival.TakeDamage(damage);
        return damage;
    }

    public void TakeDamage(int damage) {
        character.HP -= damage;
    }

    int Damage(Unit rival) {
        return Character.Damage(character, rival.character);
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

        return Math.Max(character.HP, 0);
    }
    public int Atk() {
        return character.Atk;
    }
    public int Spd() {
        return character.Spd;
    }
    public int Def() {
        return character.Def;
    }
    public int Res() {
        return character.Res;
    }

    /*
    Cada jugador podrá equipar un máximo de 2 habilidades en cada una de sus unidades.
    Estas habilidades deben ser distintas entre si para una única unidad, pero pueden repetirse entre
    unidades. Por ejemplo, si una unidad tiene equipada la habilidad New Divinity, entonces no podrá
    equipar New Divinity por segunda vez, pero cualquier otra unidad puede equipar New Divinit
    */
    public bool IsValid() {
        return (skills.Count() < 3) && AreSkillsDistinct();
    }

    bool AreSkillsDistinct() {
        var skillNames = skills.Select(skill => skill.Name).ToList();
        return skillNames.Count() == skillNames.Distinct().Count();
    }

}

