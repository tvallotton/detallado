



using System.ComponentModel.DataAnnotations;



public class Effect {
    public Stats<int> difference = new Stats<int>();
    public NeutralizedStats neutralized = new NeutralizedStats();

    public Scope scope = Scope.ALL;

}
