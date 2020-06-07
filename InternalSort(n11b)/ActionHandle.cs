namespace InternalSort_n11b_
{
    public enum Act
    {
        InsertAfter,
        InsertBefore,
        InsertBetween,
        InsertFirstElem,
        InsertLeftIn,
        InsertRightIn,
        MoveBack,
        Compare
    }

    public class ActionHandle
    {
        public int First { get; protected set; }
        public int Second { get; protected set; }
        public Act Act { get; protected set; }

        public ActionHandle(int f, int s, Act act)
        {
            First = f;
            Second = s;
            Act = act;
        }
    }
}