class Stats {
    int MaxHP;
    int HP;
    int Atk;

    int Spd;

    int Def;
    int Res;


    public Stats(Character character) {
        Atk = character.Atk;
        Spd = character.Spd;
        Def = character.Def;
        Res = character.Res;
        HP = character.HP;
        MaxHP = character.HP;

    }
}