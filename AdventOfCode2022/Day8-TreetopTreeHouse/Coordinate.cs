namespace Day8_TreetopTreeHouse;

public class Coordinate : IEquatable<Coordinate>
{
    public int row;

    public int col;

    public Coordinate(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool Equals(Coordinate? other)
    {
        if((other == null) || !GetType().Equals(other.GetType()))
        {
            return false;
        }

        Coordinate coordinate = other;

        if(row != coordinate.row || col != coordinate.col)
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
