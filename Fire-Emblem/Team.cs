using System.Reflection.Metadata.Ecma335;

class Team {
    public List<Unit> units;


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

    /*
    Cada jugador podrá escoger un máximo de 3 unidades para conformar su equipo. Los equipos deben
    tener un mínimo de 1 unidad

    Un jugador no podrá tener una unidad repetida en su equipo, pero su contrincante podrá tener las
    mismas unidades que el jugador. Por ejemplo, si el primer jugador tiene a la unidad Celica como su
    primera unidad, no podrá tener una segunda o tercera Celica en su equipo, pero el otro jugador podrá
    tener una única Celica en el mismo juego.

Player 1 Team
Lucina (Guard Bearing)
Roy (Swift Impact)
Byleth (Speed +5)
Player 2 Team
Shez (Phys. Null Follow,Mystic Boost,Atk/Res Push)

    */
    public bool IsValid() {
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
        var unitNames = units.Select(unit => unit.character.Name).ToList();
        return unitNames.Distinct().Count() == unitNames.Count();
    }

    bool AreIndividualUnitsValid() {
        return units.All(unit => unit.IsValid());

    }


    public IEnumerable<string> unitOptions() {
        foreach (var (i, unit) in LivingUnits().Enumerate()) {
            yield return $"{i}: {unit.character.Name}";
        }
    }

    public IEnumerable<Unit> LivingUnits() {
        return units.Where((unit) => unit.IsAlive());
    }
}