

using System.Diagnostics;

public struct Stats<T> where T : new() {
    public T HP;
    public T Atk;
    public T Spd;
    public T Def;
    public T Res;

    public Stats() {
        HP = new T();
        Atk = new T();
        Spd = new T();
        Def = new T();
        Res = new T();
    }

    public static Stats<bool> All() {
        var values = new Stats<bool>();
        values.HP = true;
        values.Atk = true;
        values.Spd = true;
        values.Def = true;
        values.Res = true;
        return values;
    }

    public T Get(Stat stat) {
        switch (stat) {
            case Stat.Atk: return Atk;
            case Stat.Spd: return Spd;
            case Stat.Res: return Res;
            case Stat.Def: return Def;
            case Stat.HP: return HP;
        }
        throw new UnreachableException();
    }

    public void Set(Stat stat, T value) {
        switch (stat) {
            case Stat.Atk: Atk = value; break;
            case Stat.Spd: Spd = value; break;
            case Stat.Res: Res = value; break;
            case Stat.Def: Def = value; break;
            case Stat.HP: HP = value; break;
        }
        throw new UnreachableException();
    }
}