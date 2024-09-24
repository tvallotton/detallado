using System.Reflection.Metadata.Ecma335;

class Team {
    public List<Unit> units;


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
        Console.WriteLine($"{AreQuantitiesValid()} {AreUnitsDistinct()}{AreIndividualUnitsValid()}");
        return (
            AreQuantitiesValid() &&
            AreUnitsDistinct() &&
            AreIndividualUnitsValid()
        );
    }

    bool AreQuantitiesValid() {
        return !(units.Count() < 1 || units.Count() > 3);
    }

    bool AreUnitsDistinct() {
        var unitNames = units.Select(unit => unit.Name()).ToList();
        return unitNames.Distinct().Count() == unitNames.Count();
    }

    bool AreIndividualUnitsValid() {
        return units.All(unit => unit.IsValid());

    }


    public IEnumerable<string> unitOptions() {
        foreach (var (i, unit) in LivingUnits().Enumerate()) {
            yield return $"{i}: {unit.Name()}";
        }
    }

    public IEnumerable<Unit> LivingUnits() {
        return units.Where((unit) => unit.IsAlive());
    }
}