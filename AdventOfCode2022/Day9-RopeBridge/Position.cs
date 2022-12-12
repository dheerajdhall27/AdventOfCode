namespace Day9_RopeBridge;

public class Position : IEquatable<Position>
{
    public int row;

    public int col;

    public Position(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool Equals(Position? other)
    {
        if ((other == null) || !GetType().Equals(other.GetType()))
        {
            return false;
        }

        Position coordinate = other;

        if (row != coordinate.row || col != coordinate.col)
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return (row << 2) ^ col;
    }
}
