



using System.ComponentModel.DataAnnotations;

public class Effect {
    public Values<int> diff = new Values<int>();
    public Neutralize neutralize = new Neutralize();

    public Scope scope = Scope.ALL;

}

public class Neutralize {
    public Values<bool> bonus = new Values<bool>();
    public Values<bool> penalty = new Values<bool>();
}

public enum Scope {
    ALL,
    FIRST_ATTACK,
    FOLLOW_UP,
}


public struct Values<T> where T : new() {
    public T HP;
    public T Atk;
    public T Spd;
    public T Def;
    public T Res;

    public Values() {
        HP = new T();
        Atk = new T();
        Spd = new T();
        Def = new T();
        Res = new T();
    }

    public static Values<bool> All() {
        var values = new Values<bool>();
        values.HP = true;
        values.Atk = true;
        values.Spd = true;
        values.Def = true;
        values.Res = true;
        return values;

    }
}