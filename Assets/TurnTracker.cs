public static class TurnTracker
{
    private static Side curTurn;
    public static Side CurTurn
    {
        get { return curTurn; }
        set { curTurn = value; }
    }

    static TurnTracker()
    {
        curTurn = Side.white;
    }

    public static void UpdateTurn() {
        if (curTurn == Side.white) {
            curTurn = Side.black;
        } else {
            curTurn = Side.white;
        }
    }
}
