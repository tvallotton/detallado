using System.Security;

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

    public void AnouncePercentEffect(object unit, int value, Scope scope) {
        if (value == 0) return;
        switch (scope) {
            case Scope.ALL:
                WriteLine($"{unit} reducirá el daño de los ataques del rival en un {value}%");
                break;
            case Scope.FIRST_ATTACK:
                WriteLine($"{unit} reducirá el daño del primer ataque del rival en un {value}%");
                break;
            case Scope.FOLLOW_UP:
                WriteLine($"{unit} reducirá el daño del Follow-Up del rival en un {value}%");
                break;
        }

    }

    public void AnounceExtraDamageEffect(object unit, int value, Scope scope) {
        if (value == 0) return;
        switch (scope) {
            case Scope.ALL: WriteLine($"{unit} realizará +{value} daño extra en cada ataque"); break;
            case Scope.FIRST_ATTACK: WriteLine($"{unit} realizará +{value} daño extra en su primer ataque"); break;
            case Scope.FOLLOW_UP: WriteLine($"{unit} realizará +{value} daño extra en su follow up"); break;
        }
    }

    public void AnounceAbsoluteDamageReduction(object unit, int value, Scope scope) {
        if (value == 0) return;

        WriteLine($"{unit} recibirá -{value} daño en cada ataque");
    }

    public void AnouncePercentEffectFollowUp(object unit, int value) {
        if (value == 0) return;
        WriteLine($"{unit} reducirá el daño del Follow-Up del rival en un {value}%");
    }

    public void AnounceNeutralizedEffect(object unit, object stat, object effectType) {
        var type = effectType.ToString()!.ToLower();
        WriteLine($"Los {type} de {stat} de {unit} fueron neutralizados");
    }

    public void AnounceWinner(int unit) {
        WriteLine($"Player {unit} ganó");
    }

    public void AnounceFightStarts(int round, object attacker, int turn) {
        WriteLine($"Round {round}: {attacker} (Player {turn}) comienza");
    }
    public int AskToSelectAnOption(int player, IEnumerable<object> options) {
        WriteLine($"Player {player + 1} selecciona una opción");
        var optionsText = string.Join('\n', options.Select((opt, i) => $"{i}: {opt}"));
        WriteLine(optionsText);
        return Int32.Parse(_view.ReadLine());

    }

    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message) {
        _view.WriteLine(message);
    }

    public string[] GetScript()
        => _view.GetScript();
}