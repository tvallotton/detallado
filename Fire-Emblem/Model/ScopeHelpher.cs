
public static class ScopeHelper {


    public static bool Includes(this Scope scope, Scope other) {
        return (scope == Scope.ALL) || scope == other;
    }

}