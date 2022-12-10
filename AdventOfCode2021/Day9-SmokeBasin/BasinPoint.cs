namespace Day9_SmokeBasin
{
    class BasinPoint : IEquatable<BasinPoint>
    {
        public int row;

        public int col;

        public int pointValue;

        public BasinPoint(int row, int col, int pointValue)
        {
            this.row = row;
            this.col = col;
            this.pointValue = pointValue;
        }

        public bool Equals(BasinPoint? other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            BasinPoint p = other;

            return row == p.row && col == p.col;
        }

        public override int GetHashCode()
        {
            return (row << 2) ^ col;
        }
    }
}
