using Fire_Emblem_View;

public class FireEmblemView(View _view) {
    public void AnnounceAttack(Unit attacker, Unit defender, int damage) {
        WriteLine($"{attacker} ataca a {defender} con {damage} de daño");
    }

    public void AnnounceStatEffect(Unit unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value:+#;-#;0}");
    }

    public void AnnounceStatEffectFirstAttack(Unit unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value:+#;-#;0} en su primer ataque");
    }

    public void AnnounceStatEffectFollowUp(Unit unit, object stat, int value) {
        if (value == 0) return;
        WriteLine($"{unit} obtiene {stat}{value.ToString("+#;-#;0")} en su Follow-Up");
    }

    public void AnnouncePercentEffect(Unit unit, int value, Scope scope) {
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

    public void AnnounceExtraDamageEffect(Unit unit, int value, Scope scope) {
        if (value == 0) return;
        switch (scope) {
            case Scope.ALL: WriteLine($"{unit} realizará +{value} daño extra en cada ataque"); break;
            case Scope.FIRST_ATTACK: WriteLine($"{unit} realizará +{value} daño extra en su primer ataque"); break;
            case Scope.FOLLOW_UP: WriteLine($"{unit} realizará +{value} daño extra en su follow up"); break;
        }
    }

    public void AnnounceAbsoluteDamageReduction(Unit unit, int value, Scope scope) {
        if (value == 0) return;

        WriteLine($"{unit} recibirá -{value} daño en cada ataque");
    }

    public void AnnouncePercentEffectFollowUp(Unit unit, int value) {
        if (value == 0) return;
        WriteLine($"{unit} reducirá el daño del Follow-Up del rival en un {value}%");
    }

    public void AnnounceNeutralizedEffect(Unit unit, object stat, object effectType) {
        var type = effectType.ToString()!.ToLower();
        WriteLine($"Los {type} de {stat} de {unit} fueron neutralizados");
    }

    public void AnnounceWinner(int unit) {
        WriteLine($"Player {unit} ganó");
    }

    public void AnnounceFightStarts(int round, Unit attacker, int turn) {
        WriteLine($"Round {round}: {attacker} (Player {turn}) comienza");
    }
    public int AskToSelectAnOption(int player, IEnumerable<object> options) {
        WriteLine($"Player {player + 1} selecciona una opción");
        var optionsText = string.Join('\n', options.Select((opt, i) => $"{i}: {opt}"));
        WriteLine(optionsText);
        return Int32.Parse(_view.ReadLine());

    }

    public void AnnounceHealingEffect(Unit unit, int percentage) {
        if (percentage != 0)
            WriteLine($"{unit} recuperará HP igual al {percentage}% del daño realizado en cada ataque");
    }


    public List<string> WriteSelectTeamOptions(string teamsFolder) {
        WriteLine("Elige un archivo para cargar los equipos");
        var list = Directory.EnumerateFiles(teamsFolder, "*.txt").ToList();
        list.Sort();
        list.Select((file, index) => {
            WriteLine($"{index}: {Path.GetFileName(file)}");
            return index;
        }).Last();
        return list;
    }

    public void AnnounceNoFollowUp() {
        WriteLine("Ninguna unidad puede hacer un follow up");
    }

    public void AnnounceHealedFighter(Unit unit, int healed) {
        if (healed != 0)
            WriteLine($"{unit} recupera {healed} HP luego de atacar y queda con {unit.GetHP()} HP.");
    }
    public void AnnounceCounterAttackNegation(Unit rival) {
        WriteLine($"{rival} no podrá contraatacar");
    }
    public void AnnounceCounterAttackNegationBlocker(Unit rival) {
        WriteLine($"{rival} neutraliza los efectos que previenen sus contraataques");
    }

    public void AnnounceAfterCombatDamage(Unit unit, int damage) {
        WriteLine($"{unit} recibe {damage} de daño despues del combate");
    }

    public void AnnounceNoAdvantage() {
        WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }

    public void AnnouncePlayerCannotFolowUp(Unit unit) {
        WriteLine($"{unit} no puede hacer un follow up");
    }

    public void AnnounceBeforeCombatDamage(Unit unit, int damage, int hp) {
        WriteLine($"{unit} recibe {damage} de daño antes de iniciar el combate y queda con {hp} HP");
    }

    public void AnnounceAdvantage(string first, string second) {
        WriteLine($"{first} tiene ventaja con respecto a {second}");
    }
    public string ReadLine() => _view.ReadLine();

    public void AnnounceFightResults(Unit attacker, Unit defender) {
        _view.WriteLine($"{attacker} ({attacker.GetHP()}) : {defender} ({defender.GetHP()})");
    }



    public void WriteLine(string message) {
        _view.WriteLine(message);
    }

    public string[] GetScript()
        => _view.GetScript();

}