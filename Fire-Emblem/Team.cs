class Team {
    List<Unit> units;


    public Team() {
        units = new List<Unit>();
    }

    public void addUnit(Unit unit) {
        units.Add(unit);
    }

    public override string ToString() {

        string unitStrings = String.Join(",\n", units.ToArray().Select(unit => unit.ToString()));
        return $"Team {{ units: {unitStrings} }}";
    }
}