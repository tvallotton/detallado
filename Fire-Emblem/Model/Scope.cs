

public enum Scope {

    ALL,
    FIRST_ATTACK,
    FOLLOW_UP,
}


public static class ScopeHelper {


    public static bool Includes(this Scope scope, Scope other) {
        return (scope == Scope.ALL) || scope == other;
    }

}