

using Fire_Emblem;

class LanceAgility : BaseSkill {
    public override string Name() {
        return "Lance Agility";
    }

    public override bool Condition(Game game, int player) {
        return game.Fighter(player).Weapon() == Weapon.Lance;
    }

    public override Effect PlayerEffect(Game game, int player) {
        var effect = new Effect();
        effect.difference.Spd = 12;
        effect.difference.Atk = -6;
        return effect;
    }

}