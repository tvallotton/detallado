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
    public static bool HasAdvantageOver(this Weapon first, Weapon second) {
        return ((first == Weapon.Sword) && (second == Weapon.Axe))
            || ((first == Weapon.Lance) && (second == Weapon.Sword))
            || ((first == Weapon.Axe) && (second == Weapon.Lance));
    }

    public static double WTB(this Weapon player, Weapon rival) {
        if (player.HasAdvantageOver(rival)) {
            return 1.2;
        } else if (rival.HasAdvantageOver(player)) {
            return 0.8;
        } else {
            return 1;
        }
    }
}