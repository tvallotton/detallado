


class Player {
    Team team;


    public Player() {
        team = new Team();
    }

    public void addUnit(Unit unit) {
        team.addUnit(unit);
    }

    public override string ToString() {
        return $"Player {{ team: {team} }}";
    }


}


