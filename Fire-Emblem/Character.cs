
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class Character {
    public string Name { get; set; }
    public Weapon Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public int HP { get; set; }
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }

    public override string ToString() {
        return (
            $"Character {{ Name: {Name}, Weapon: {Weapon}," +
            $"Gender {Gender}, DeathQuote: {DeathQuote}, HP: {HP}," +
            $" Atk: {Atk}, Spd: {Spd}, Def: {Def}, Res: {Res} }}"
        );
    }


    public static int Damage(Character attacker, Character defender) {
        int attack = (int)(attacker.Atk * WTB(attacker, defender));
        int defense = Defense(attacker, defender);
        return Math.Max(attack - defense, 0);
    }

    static double WTB(Character attacker, Character defender) {
        return attacker.Weapon.WTB(defender.Weapon);
    }

    static int Defense(Character attacker, Character defender) {
        if (attacker.Weapon == Weapon.Magic) {
            return defender.Res;
        }
        return defender.Def;
    }
}

