


using System.Diagnostics;
using System.Text.Json;

static class Utils {


    public static CharacterDto GetCharacterByName(string name) {
        CharacterDto? character = ReadCharacterJSON().Find(character => character.Name == name);

        Trace.Assert(character != null);

        return character!;
    }

    static List<CharacterDto> ReadCharacterJSON() {
        string json = File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<CharacterDto>>(json);
        Trace.Assert(characters != null);
        return characters;
    }
}