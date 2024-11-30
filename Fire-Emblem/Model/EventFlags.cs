public class HistoryTracker {

    private Unit? _latestOpponent;

    public Unit? LatestOpponent {
        set { _latestOpponent = value; }
        get { return _latestOpponent; }
    }

    private bool _hasAttackedThisRound = false;

    public bool HasAttackedThisRound {
        get { return _hasAttackedThisRound; }
    }


    private List<int> _damageCaused = new List<int>();


    public void ClearRoundEvents() {
        _hasAttackedThisRound = false;
    }

    public void AddDamageCaused(int damage) {
        _hasAttackedThisRound = true;
        _damageCaused.Add(damage);
    }

    public int LastDamageCaused() {
        return _damageCaused.LastOrDefault();
    }


}