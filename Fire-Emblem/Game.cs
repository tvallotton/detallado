using System.Formats.Asn1;
using System.Security;
using Fire_Emblem_View;

using System.Text.RegularExpressions;
namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    private List<Player> players;
    private int turn;
    private int attacker;

    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;

        players = new List<Player>();


    }

    public void Play() {
        SelectTeam();

    }

    void SelectTeam() {
        List<string> options = WriteSelectTreamOptions();
        int answer = Int32.Parse(_view.ReadLine());
        LoadTeams(options[answer]);
    }

    List<string> WriteSelectTreamOptions() {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        var list = Directory.EnumerateFiles(_teamsFolder, "*.txt").ToList();
        list.Sort();
        foreach (var (index, file) in list.Enumerate()) {
            _view.WriteLine($"{index}: {Path.GetFileName(file)}");
        }
        return list;
    }


    void LoadTeams(string file) {

        var playerLine = new Regex(@"Player [12] Team");

        var unitLine = new Regex(@"^([^)]+)(?:| \(([^)]+)\))$");


        foreach (var line in File.ReadLines(file)) {
            _view.WriteLine(line);
            _view.WriteLine($"{players.Count()}");
            if (playerLine.Match(line).Success) {
                players.Add(new Player());
                _view.WriteLine("continue");
                continue;
            }

            var unitMatch = unitLine.Match(line);

            var unitName = unitMatch.Groups[1].Value;

            players.Last().addUnit(new Unit(unitName));
        }
    }

}

// Player 1 Team
// Seliph (Blinding Flash)
// Dimitri (Belief in Love)
// Ephraim (Frenzy)
// Roy (Brazen Atk/Spd)
// Corrin (Sun-Twin Wing)
// Player 2 Team
// Lyn (True Dragon Wall)
