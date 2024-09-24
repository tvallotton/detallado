using System.Formats.Asn1;
using System.Security;
using Fire_Emblem_View;

using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.IO.Pipes;
namespace Fire_Emblem;

public class Game {
    private View _view;
    private string _teamsFolder;

    public List<Player> players;
    public int turn;
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
        while (!IsGameOver()) {
            PlayRound();
        }
        AnounceWinner();

    }

    void PlayRound() {
        SelectPlayers();
        Fight();
        EndRoundClenup();
    }

    void EndRoundClenup() {
        turn = (turn + 1) & 1;
        round.number += 1;
        players[0].ClearFighter();
        players[1].ClearFighter();
    }

    bool IsGameOver() {
        return players.Any((player) => player.HasLost());
    }

    void AnounceWinner() {
        int winner = players[0].HasLost() ? 2 : 1;
        _view.WriteLine($"Player {winner} ganó");
    }

    void SelectPlayers() {
        foreach (var i in turnIter()) {
            _view.WriteLine($"Player {i + 1} selecciona una opción");
            _view.WriteLine(players[i].UnitOptions());
            players[i].SetFighter(Int32.Parse(_view.ReadLine()));
        }
    }

    IEnumerable<int> turnIter() {
        if (turn == 0)
            return [0, 1];
        else return [1, 0];
    }

    void Fight() {
        AnounceFightStarts();
        AnounceAdvantage();
        SetupEffects();
        LaunchAttack();
        if (Defender().IsAlive()) {
            RetailateAttack();
        } else {
            FightResults();
            return;
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
        if (Defender().Spd() + 5 <= Attacker().Spd()) {
            LaunchAttack();
        } else if (Attacker().Spd() + 5 <= Defender().Spd()) {
            RetailateAttack();
        } else {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
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
    }

    void SetupEffects() {
        foreach (var i in turnIter()) {
            SetupEffectsForPlayer(i);
        }
    }

    void SetupEffectsForPlayer(int player) {
        foreach (var skill in players[player].Skills()) {
            var anouncement = skill.Install(this, player);
            if (anouncement != null)
                _view.WriteLine(anouncement);
        }
    }

    public Unit Fighter(int player) {
        return players[player & 1].GetFighter();
    }



    void AnounceAdvantage() {
        if (Attacker().HasAdvantageOver(Defender())) {
            _view.WriteLine($"{Attacker()} ({Attacker().Weapon()}) tiene ventaja con respecto a {Defender()} ({Defender().Weapon()})");
        } else if (Defender().HasAdvantageOver(Attacker())) {
            _view.WriteLine($"{Defender()} ({Defender().Weapon()}) tiene ventaja con respecto a {Attacker()} ({Attacker().Weapon()})");
        } else {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public Unit Attacker() {
        return Fighter(turn);
    }

    public Unit Defender() {
        return Fighter(turn + 1);
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

    static Regex PLAYER_LINE = new Regex(@"Player [12] Team");

    static Regex UNIT_LINE = new Regex(@"^([^)]+)(?:| \(([^)]+)\))$");


    void LoadTeams(string file) {
        foreach (var line in File.ReadLines(file)) {
            addPlayerFromFileLine(line);
        }
    }

    void addPlayerFromFileLine(string line) {
        if (PLAYER_LINE.Match(line).Success) {
            players.Add(new Player());
            return;
        }

        var unitMatch = UNIT_LINE.Match(line);

        var unitName = unitMatch.Groups[1].Value;
        var unitSkills = unitMatch.Groups[2].Value.Split(",");
        players.Last().AddUnit(new Unit(unitName, unitSkills));
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

