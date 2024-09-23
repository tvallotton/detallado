using System.Formats.Asn1;
using System.Security;
using Fire_Emblem_View;

using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.ComponentModel;
namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    private List<Player> players;
    private int turn;
    private Round round;


    public Game(View view, string teamsFolder) {
        _view = view;
        _teamsFolder = teamsFolder;
        players = new List<Player>();
        round = new Round();
        turn = 0;


    }

    public void Play() {
        SelectTeam();
        if (!AreTeamsValid()) {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }
        PlayRound();
    }

    void PlayRound() {
        SelectPlayers();
        while (!IsGameOver()) {
            Fight();
        }
        AnounceWinner();
    }

    bool IsGameOver() {
        return players.Any((player) => player.HasLost());
    }

    void AnounceWinner() {
        int winner = players[0].HasLost() ? 2 : 1;
        _view.WriteLine($"Player {winner} ganó");
    }

    void SelectPlayers() {
        for (var i = 0; i < 2; i++) {
            _view.WriteLine($"Player {i + 1} selecciona una opción");
            _view.WriteLine(players[i].unitOptions());
            players[i].fighter = Int32.Parse(_view.ReadLine());
        }
    }

    void Fight() {
        AnounceFightStarts();

        LaunchAttack();
        if (Defender().IsAlive()) {
            RetailateAttack();
        } else {
            _view.WriteLine("se murió");
        }
        if (Attacker().IsAlive()) {
            FollowUp();
        }
        FightResults();
    }

    void FightResults() {
        _view.WriteLine($"{Attacker()} ({Attacker().HP()}) : {Defender()} ({Defender().HP()})");
    }

    void FollowUp() {
        if (Defender().Spd() + 5 < Attacker().Spd()) {
            LaunchAttack();
        } else if (Attacker().Spd() + 5 < Defender().Spd()) {
            RetailateAttack();
        } else {
            _view.WriteLine("No follow up");
        }
    }

    void LaunchAttack() {
        _view.WriteLine($"{Attacker()} ataca a {Defender()} con {Attacker().Attack(Defender())} de daño");
    }

    void RetailateAttack() {
        _view.WriteLine($"{Defender()} ataca a {Attacker()} con {Defender().Attack(Attacker())} de daño");
    }

    void AnounceFightStarts() {
        _view.WriteLine($"Round {round.number}: {Attacker()} (Player {turn + 1}) comienza");

        if (Attacker().HasAdvantageOver(Defender())) {
            _view.WriteLine($"{Attacker()} ({Attacker().Weapon()}) tiene ventaja con respecto a {Defender()} ({Defender().Weapon()})");
        } else if (Defender().HasAdvantageOver(Attacker())) {
            _view.WriteLine($"{Defender()} ({Defender().Weapon()}) tiene ventaja con respecto a {Attacker()} ({Attacker().Weapon()})");
        } else {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }


    Unit Attacker() {
        return players[turn].getFighter();
    }

    Unit Defender() {
        return players[(turn + 1) & 1].getFighter();
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

