using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_HydrothermalVenture
{
    public class HydrothermalVentCreator
    {
        private Dictionary<Point, int> pointsDictionary;

        public HydrothermalVentCreator()
        {
            pointsDictionary = new Dictionary<Point, int>();
        }

        public void ParseHydrothermalVentCoordsAndCreateLines(string[] lines)
        {
            foreach (var line in lines)
            {
                var coords = line.Split("->");

                var pointACoords = coords[0].Trim().Split(",");
                var pointBCoords = coords[1].Trim().Split(",");

                var pointA = new Point(Convert.ToInt32(pointACoords[0]), Convert.ToInt32(pointACoords[1]));
                var pointB = new Point(Convert.ToInt32(pointBCoords[0]), Convert.ToInt32(pointBCoords[1]));

                CreatePointsInBetweenAndAddToDictionary(pointA, pointB);
            }
        }

        public int GetNumberOfCoordsWithOverlappingVentLines()
        {
            return pointsDictionary.Count(item => item.Value > 1);
        }

        private void CreatePointsInBetweenAndAddToDictionary(Point A, Point B)
        {
            int min;
            int max;
            if (IsXCoordSame(A, B))
            {
                min = Math.Min(A.YCoord, B.YCoord);
                max = Math.Max(A.YCoord, B.YCoord);

                for (int i = min; i <= max; i++)
                {
                    Point p = new Point(A.XCoord, i);

                    if (!pointsDictionary.TryAdd(p, 1))
                    {
                        pointsDictionary[p]++;
                    }
                }
            }
            else if (IsYCoordSame(A, B))
            {
                min = Math.Min(A.XCoord, B.XCoord);
                max = Math.Max(A.XCoord, B.XCoord);

                for (int i = min; i <= max; i++)
                {
                    Point p = new Point(i, A.YCoord);

                    if (!pointsDictionary.TryAdd(p, 1))
                    {
                        pointsDictionary[p]++;
                    }
                }
            }
            else if(IsDiagonal(A, B))
            {
                int x; int y;
                if(A.YCoord < B.YCoord)
                {
                    x = A.XCoord;
                    y = A.YCoord;

                    if(A.XCoord < B.XCoord)
                    {
                        while(x <= B.XCoord && y <= B.YCoord)
                        {
                            Point p = new Point(x, y);

                            if (!pointsDictionary.TryAdd(p, 1))
                            {
                                pointsDictionary[p]++;
                            }

                            x++;
                            y++;
                        }
                    } else
                    {
                        while (x >= B.XCoord && y <= B.YCoord)
                        {
                            Point p = new Point(x, y);

                            if (!pointsDictionary.TryAdd(p, 1))
                            {
                                pointsDictionary[p]++;
                            }

                            x--;
                            y++;
                        }
                    }
                }
                else
                {
                    x = A.XCoord;
                    y = A.YCoord;

                    if(A.XCoord < B.XCoord)
                    {
                        while (x <= B.XCoord && y >= B.YCoord)
                        {
                            Point p = new Point(x, y);

                            if (!pointsDictionary.TryAdd(p, 1))
                            {
                                pointsDictionary[p]++;
                            }

                            x++;
                            y--;
                        }
                    }
                    else 
                    {
                        while (x >= B.XCoord && y >= B.YCoord)
                        {
                            Point p = new Point(x, y);

                            if (!pointsDictionary.TryAdd(p, 1))
                            {
                                pointsDictionary[p]++;
                            }

                            x--;
                            y--;
                        }
                    }
                }
            }
        }

        private bool IsXCoordSame(Point A, Point B)
        {
            return A.XCoord == B.XCoord;
        }

        private bool IsYCoordSame(Point A, Point B)
        {
            return A.YCoord == B.YCoord;
        }

        private bool IsDiagonal(Point A, Point B)
        {
            int y = Math.Abs(A.YCoord - B.YCoord);
            int x = Math.Abs(A.XCoord - B.XCoord);

            return x == y;
        }
    }
}
