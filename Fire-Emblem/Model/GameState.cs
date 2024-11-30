public class GameState {

    public int turn = 0;
    public int round = 1;
    private List<Player> _players = new List<Player>();

    public Unit GetFighter(int player) {
        return _players[player & 1].GetFighter();
    }

    public Player GetPlayer(int player) {
        return _players[player];
    }

    public IEnumerable<int> IterOverTurns() {
        if (turn == 0)
            return [0, 1];
        else return [1, 0];
    }

    public bool IsPlayersTurn(int player) {
        return turn == (player & 1);
    }

    public void AddPlayers(IEnumerable<Player> players) {
        _players = players.ToList();
    }

    public bool IsGameOver() {
        return _players.Any((player) => player.HasLost());
    }

    public bool AreTeamsValid() {
        return _players.All(player => player.IsTeamValid());
    }

    public void EndRound() {
        turn = (turn + 1) & 1;
        round += 1;

        GetFighter(1).SetLatestOpponent(GetFighter(0));
        GetFighter(0).SetLatestOpponent(GetFighter(1));
        _players[0].ClearRoundState();
        _players[1].ClearRoundState();
    }
}