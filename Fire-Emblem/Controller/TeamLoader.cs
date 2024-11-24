using System.Text.RegularExpressions;

public class TeamLoader(string file) {
    List<Player> players = new List<Player>();


    static Regex _playerLine = new Regex(@"Player [12] Team");

    static Regex _unitLine = new Regex(@"^([^)]+)(?:| \(([^)]+)\))$");


    public IEnumerable<Player> LoadTeams() {
        foreach (var line in File.ReadLines(file)) {
            AddPlayerFromFileLine(line);
        }
        return players;
    }

    void AddPlayerFromFileLine(string line) {
        if (_playerLine.Match(line).Success) {
            players.Add(new Player());
            return;
        }

        var unitMatch = _unitLine.Match(line);

        var unitName = unitMatch.Groups[1].Value;
        var unitSkills = unitMatch.Groups[2].Value.Split(",");
        players.Last().AddUnit(new Unit(unitName, unitSkills));
    }
}


