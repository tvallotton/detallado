namespace Fire_Emblem_View;

public class View {
    private readonly AbstractView _view;

    public static View BuildConsoleView()
        => new View(new ConsoleView());

    public static View BuildTestingView(string pathTestScript)
        => new View(new TestingView(pathTestScript));

    public static View BuildManualTestingView(string pathTestScript)
        => new View(new ManualTestingView(pathTestScript));

    private View(AbstractView newView) {
        _view = newView;
    }

    public void AnounceAttack(object attacker, object defender, int damage) {
        WriteLine($"{attacker} ataca a {defender} con {damage} de daño");
    }

    public void AnounceStatEffect(object unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value.ToString("+#;-#;0")}");
    }

    public void AnounceStatEffectFirstAttack(object unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value.ToString("+#;-#;0")} en su primer ataque");
    }

    public void AnounceStatEffectFollowUp(object unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value.ToString("+#;-#;0")} en su Follow-Up");
    }

    public void AnouncePercentEffect(object unit, int value) {
        if (value == 0) return;
        WriteLine($"{unit} reducirá el daño de los ataques del rival en un {value}%");
    }


    public void AnouncePercentEffectFirstAttack(object unit, int value) {
        if (value == 0) return;
        WriteLine($"{unit} reducirá el daño del primer ataque del rival en un {value}%");
    }

    public void AnounceNeutralizedEffect(object unit, object stat, object effectType) {
        var type = effectType.ToString()!.ToLower();
        WriteLine($"Los {type} de {stat} de {unit} fueron neutralizados");
    }

    public void AnounceNeutralizedBonus(object unit, object stat) {
        WriteLine($"Los bonus de {stat} de {unit} fueron neutralizados");
    }

    public void AnounceNeutralizedPenalty(object unit, object stat) {
        WriteLine($"Los penalty de {stat} de {unit} fueron neutralizados");
    }

    public void AnounceWinner(int unit) {
        WriteLine($"Player {unit} ganó");
    }

    public void AnounceFightStarts(int round, object attacker, int turn) {
        WriteLine($"Round {round}: {attacker} (Player {turn}) comienza");
    }


    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message) {
        _view.WriteLine(message);
    }

    public string[] GetScript()
        => _view.GetScript();
}