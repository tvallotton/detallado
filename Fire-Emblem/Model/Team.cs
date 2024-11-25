using System.Reflection.Metadata.Ecma335;

class Team {
    public List<Unit> units;

    private int _minValidUnitsPerTeam = 1;
    private int _maxValidUnitsPerTeam = 3;

    public Team() {
        units = new List<Unit>();
    }

    public void AddUnit(Unit unit) {
        units.Add(unit);
    }

    public override string ToString() {

        string unitStrings = String.Join(",\n", units.ToArray().Select(unit => unit.ToString()));
        return $"Team {{ units: {unitStrings} }}";
    }


    public bool IsValid() {
        return (
            AreQuantitiesValid() &&
            AreUnitsDistinct() &&
            AreIndividualUnitsValid()
        );
    }

    bool AreQuantitiesValid() {
        return !(units.Count() < _minValidUnitsPerTeam || units.Count() > _maxValidUnitsPerTeam);
    }

    bool AreUnitsDistinct() {
        var unitNames = units.Select(unit => unit.GetName()).ToList();
        return unitNames.Distinct().Count() == unitNames.Count();
    }

    bool AreIndividualUnitsValid() {
        return units.All(unit => unit.IsValid());

    }



    public IEnumerable<Unit> LivingUnits() {
        return units.Where((unit) => unit.IsAlive());
    }
}