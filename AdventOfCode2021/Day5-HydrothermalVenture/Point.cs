using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_HydrothermalVenture
{
    public class Point : IEquatable<Point>
    {
        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public Point(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public bool Equals(Point? other)
        {
            if((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            Point p = (Point)other;

            return XCoord == p.XCoord && YCoord == p.YCoord;
        }

        public override int GetHashCode()
        {
            return (XCoord << 2) ^ YCoord;
        }
    }
}
