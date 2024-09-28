

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string Name() {
        return "Bow Agility";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Bow;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.diff.Spd = 12;
        effect.diff.Atk = -6;
        return effect;
    }

}