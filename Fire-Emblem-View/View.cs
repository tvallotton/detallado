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

    public void AnounceEffect(object unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value.ToString("+#;-#;0")}");
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

    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message) {
        _view.WriteLine(message);
    }

    public string[] GetScript()
        => _view.GetScript();
}