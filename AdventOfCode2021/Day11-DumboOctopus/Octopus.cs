namespace Day11_DumboOctopus;

class Octopus : IEquatable<Octopus>
{
    public int row;

    public int col;

    public Octopus(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool Equals(Octopus? other)
    {
        if ((other == null) || !this.GetType().Equals(other.GetType()))
        {
            return false;
        }

        Octopus p = other;

        return row == p.row && col == p.col;
    }

    public override int GetHashCode()
    {
        return (row << 2) ^ col;
    }
}
