using Fire_Emblem_View;
namespace Fire_Emblem;


public class Game
{
    private FireEmblemView _view;
    private string _teamsFolder;

    private GameState _gameState;

    public Game(View view, string teamsFolder)
    {
        _view = new FireEmblemView(view);
        _teamsFolder = teamsFolder;
        _gameState = new GameState();
    }

    public void Play()
    {
        SelectTeam();
        if (!_gameState.AreTeamsValid())
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }
        while (!_gameState.IsGameOver())
        {
            PlayRound();
        }
        AnnounceWinner();
    }

    void PlayRound()
    {
        SelectPlayers();
        Fight();
        _gameState.EndRound();
    }



    void AnnounceWinner()
    {
        Player firstPlayer = _gameState.GetPlayer(0);
        int winner = firstPlayer.HasLost() ? 2 : 1;
        _view.AnnounceWinner(winner);
    }

    void SelectPlayers()
    {
        foreach (var playerIndex in _gameState.IterOverTurns())
        {
            Player player = _gameState.GetPlayer(playerIndex);
            var choice = _view.AskToSelectAnOption(playerIndex, player.LivingUnits());
            player.SetFighter(choice);
        }
    }

    void Fight()
    {
        new FightController(_gameState, _view).Fight();
    }

    void SelectTeam()
    {
        List<string> options = _view.WriteSelectTeamOptions(_teamsFolder);
        int answer = Int32.Parse(_view.ReadLine());
        var players = new TeamLoader(options[answer]).LoadTeams();
        _gameState.AddPlayers(players);
    }


}

