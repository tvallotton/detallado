

using Fire_Emblem;

class BowAgility : BaseSkill {
    public override string Name { get; } = "Bow Agility";

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Bow;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 12;
        effect.difference.Atk = -6;
        return effect;
    }

}