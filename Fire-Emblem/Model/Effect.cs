



using System.ComponentModel.DataAnnotations;
using System.Diagnostics;



public class Effect {
    public Stats<int> difference = new Stats<int>();

    public Stats<bool> neutralizedBonus = new Stats<bool>();
    public Stats<bool> neutralizedPenalty = new Stats<bool>();

    public Scope scope = Scope.ALL;


    public Stats<bool> GetNeutralized(EffectType effectType) {
        switch (effectType) {
            case EffectType.Bonus: return neutralizedBonus;
            case EffectType.Penalty: return neutralizedPenalty;
        }
        throw new UnreachableException();
    }

}
