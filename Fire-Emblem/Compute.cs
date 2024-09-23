



using System.Data;

static class Compute {

    static int Damage(Character attacker, Character defender) {
        int attack = (int)(attacker.Atk * WTB(attacker, defender));
        int defense = Defense(attacker, defender);
        return attack - defense;
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