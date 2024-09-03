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
        if (!AreTeamsValid()) {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }

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
            if (playerLine.Match(line).Success) {
                players.Add(new Player());
                continue;
            }

            var unitMatch = unitLine.Match(line);

            var unitName = unitMatch.Groups[1].Value;
            var unitSkills = unitMatch.Groups[2].Value.Split(",");
            players.Last().addUnit(new Unit(unitName, unitSkills));
        }
    }


    bool AreTeamsValid() {
        foreach (var player in players) {
            if (!player.IsTeamValid()) {
                return false;
            }
        }
        return true;
    }
}

