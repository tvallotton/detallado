


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

    public static Character GetCharacterByName(string name) {
        Character? character = ReadCharacterJSON().Find(character => character.Name == name);

        Trace.Assert(character != null);

        return character!;
    }

    static List<Character> ReadCharacterJSON() {
        string json = File.ReadAllText("characters.json");
        var characters = JsonSerializer.Deserialize<List<Character>>(json);
        Trace.Assert(characters != null);
        return characters;
    }
}