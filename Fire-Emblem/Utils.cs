


using System.Diagnostics;
using System.Text.Json;

static class Utils {
    public static IEnumerable<Tuple<int, T>> Enumerate<T>(this IEnumerable<T> list) {
        int id = 0;
        foreach (var elem in list) {
            yield return new Tuple<int, T>(id, elem);
            id++;
        }
    }

    public static UnitInfo GetCharacterByName(string name) {
        UnitInfo? character = ReadCharacterJSON().Find(character => character.Name == name);

        Trace.Assert(character != null, $"charachter of name {name} could not be found.");

        return character!;
    }

    static List<UnitInfo> ReadCharacterJSON() {
        string json = File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<UnitInfo>>(json);
        Trace.Assert(characters != null, "The character list could not be deserialized");
        Trace.Assert(characters.Count() != 0, "The character list is empty");
        return characters;
    }
}