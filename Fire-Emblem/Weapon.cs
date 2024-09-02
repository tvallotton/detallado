using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Weapon {

    Sword,
    Lance,
    Axe,
    Bow,
    Magic
}


static class WeaponExtension {
    public static bool HasAdvantage(this Weapon first, Weapon second) {
        return ((first == Weapon.Sword) && (second == Weapon.Axe))
            || ((first == Weapon.Lance) && (second == Weapon.Sword))
            || ((first == Weapon.Axe) && (second == Weapon.Lance));
    }
}