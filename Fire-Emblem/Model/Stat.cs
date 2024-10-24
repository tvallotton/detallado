using System.Runtime.InteropServices;

public enum Stat {
    Atk,
    Spd,
    Def,
    Res,
    HP
}

public class StatConstants {
    public static Stat[] ORDERED = {
            Stat.Atk,
            Stat.Spd,
            Stat.Def,
            Stat.Res,
    };

}
