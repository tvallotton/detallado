



using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Json;


class Unit {
    Character character;

    public Unit(string name) {


        string json = File.ReadAllText("characters.json");
        List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

        Debug.Assert(characters != null);

        Character? character = characters.Find(character => character.Name == name);

        Debug.Assert(character != null);


        this.character = character;


    }

    public override string ToString() {
        return $"Unit {{ character: {character} }}";
    }

}

