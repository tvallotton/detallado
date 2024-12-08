



using System.ComponentModel.DataAnnotations;
using System.Diagnostics;



public class Effect {
    public Stats<int> difference = new Stats<int>();

    public Stats<bool> neutralizedBonus = new Stats<bool>();
    public Stats<bool> neutralizedPenalty = new Stats<bool>();

    public Scope scope = Scope.ALL;

    public int extraDamage = 0;

    public int percentagewiseDamageReduction = 0;

    public int absoluteDamageReduction = 0;

    public int healing = 0;

    public int counterAttackNegation = 0;

    public int counterAttackNegationBlocker = 0;

    public int damageBeforeCombat = 0;

    public int damageAfterCombat = 0;

    public int afterCombatHealing = 0;

    public int followUpGuarantee = 0;

    public int followUpNegation = 0;


    public Stats<bool> GetNeutralized(EffectType effectType) {
        switch (effectType) {
            case EffectType.Bonus: return neutralizedBonus;
            case EffectType.Penalty: return neutralizedPenalty;
        }
        throw new UnreachableException();
    }

    public int GetByName(EffectName effect) {
        switch (effect) {
            case EffectName.ExtraDamage: return extraDamage;
            case EffectName.PercentagewiseDamageReduction: return percentagewiseDamageReduction;
            case EffectName.AbsoluteDamageReduction: return absoluteDamageReduction;
            case EffectName.Healing: return healing;
            case EffectName.CounterAttackNegation: return counterAttackNegation;
            case EffectName.CounterAttacKNegationBlocker: return counterAttackNegationBlocker;
            case EffectName.DamageAfterCombat: return damageAfterCombat;
            case EffectName.DamageBeforeCombat: return damageBeforeCombat;
            case EffectName.HealingAfterCombat: return afterCombatHealing;
            case EffectName.FollowUpGuarantee: return followUpGuarantee;
            case EffectName.FollowUpNegation: return followUpNegation;
            default: return 0;
        }
    }
}
