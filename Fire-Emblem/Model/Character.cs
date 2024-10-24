
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class CharacterDto {
    public string Name { get; set; }
    public Weapon Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public int HP { get; set; }
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }

}

