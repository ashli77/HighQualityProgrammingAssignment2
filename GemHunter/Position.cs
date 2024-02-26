namespace GemHunter
{
    public class Position
    {
        #region properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region constructor
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
