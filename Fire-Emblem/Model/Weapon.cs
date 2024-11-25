using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Weapon {

    Sword,
    Lance,
    Axe,
    Bow,
    Magic
}

