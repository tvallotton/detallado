

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
}