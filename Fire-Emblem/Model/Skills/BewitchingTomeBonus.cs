
class BewitchingTomeBonus : BaseSkill {
    public override string name { get; } = "Bewitching Tome";



    public override BaseCondition condition { get; } = (
        new OnTurn(Subject.Self)
            .Or(new OnWeapon(Subject.Rival, Weapon.Bow))
            .Or(new OnWeapon(Subject.Rival, Weapon.Magic))
            .DependsOn(EffectDependency.Stats)
    );

    public override IEnumerable<Effect> PlayerEffects(GameState game, int player) {
        var unit = game.GetFighter(player);

        yield return new Effect {
            percentagewiseDamageReduction = 30,
            scope = Scope.FIRST_ATTACK,
        };

        yield return new Effect {

            afterCombatHealing = 7,
            difference = new Stats<int> {
                Def = 5,
                Res = 5,
                Spd = 5 + unit.GetStat(Stat.Spd) / 5,
                Atk = 5 + unit.GetStat(Stat.Spd) / 5,
            }
        };
    }


}