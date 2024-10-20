

using Fire_Emblem;

class SpdResPlus5 : BaseSkill {
    public override string Name { get; } = "Sword Agility";

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Sword;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 10;
        effect.difference.Atk = -6;
        return effect;
    }

}