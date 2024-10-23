



using System.ComponentModel.DataAnnotations;



public class Effect {
    public Stats<int> difference = new Stats<int>();

    public Stats<bool> neutralizedBonus = new Stats<bool>();
    public Stats<bool> neutralizedPenalty = new Stats<bool>();
    // public NeutralizedStats neutralized = new NeutralizedStats();

    public Scope scope = Scope.ALL;

}
