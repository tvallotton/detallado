

using Fire_Emblem;

public abstract class BaseCondition {
    public abstract bool Check(Game game, int player);


    public BaseCondition And(BaseCondition condition) {
        return new And(this, condition);
    }

    public BaseCondition Or(BaseCondition condition) {
        return new And(this, condition);
    }


}

