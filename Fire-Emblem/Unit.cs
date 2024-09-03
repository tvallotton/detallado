



using System.ComponentModel;
using System.Diagnostics;
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
        return $"Unit {{ character: {character} }}";
    }


    /*
    Cada jugador podrá equipar un máximo de 2 habilidades en cada una de sus unidades.
    Estas habilidades deben ser distintas entre si para una única unidad, pero pueden repetirse entre
    unidades. Por ejemplo, si una unidad tiene equipada la habilidad New Divinity, entonces no podrá
    equipar New Divinity por segunda vez, pero cualquier otra unidad puede equipar New Divinit
    */
    public bool IsValid() {
        if (skills.Count() < 3) {
            return false;
        }

        var skillNames = skills.Select(skill => skill.Name).ToList();

        return skillNames.Count() == skillNames.Distinct().Count();
    }

}

