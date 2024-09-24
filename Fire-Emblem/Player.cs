


using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Fire_Emblem;

public class Player {
    Team team;
    public int? fighter;

    public Player() {
        team = new Team();
    }

    public Unit GetFighter() {
        Trace.Assert(fighter != null, "A fighter hasn't been picked yet.");
        return team.units[fighter ?? 0];
    }

    public void SetFighter(int index) {
        fighter = team
            .units
            .Enumerate()
            .Where((unit) => unit.Item2.IsAlive())
            .ElementAt(index)
            .Item1;
    }

    public void AddUnit(Unit unit) {
        team.addUnit(unit);
    }

    public void AddEffect(Effect effect) {
        GetFighter().AddEffect(effect);
    }

    public override string ToString() {
        return $"Player {{ team: {team} }}";
    }


    public bool IsTeamValid() {
        return team.IsValid();
    }

    public string UnitOptions() {
        return string.Join("\n", team.unitOptions());
    }

    public bool HasLost() {
        return !team.units.Any((unit) => unit.IsAlive());
    }

    public IEnumerable<Skill> Skills() {
        return GetFighter().skills;
    }

    public void ClearFighter() {
        GetFighter().ClearEffects();
        fighter = null;
    }


}


