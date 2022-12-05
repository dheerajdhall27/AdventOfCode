namespace Day5_HydrothermalVenture;
internal class HydrothermalVent
{
    private Dictionary<Point, int> _lineDictionary;

    public HydrothermalVent()
    {
        _lineDictionary = new Dictionary<Point, int>();
    }

    public void AddLineToDictionaryPartOne(Point pointA, Point pointB)
    {
        if(PointsAreOnHorizontalOrVerticalLine(pointA, pointB))
        {
            AddHorizontalOrVerticalLineToDictionary(pointA, pointB);
        }
    }

    public void AddLineToDictionary(Point pointA, Point pointB)
    {
        if (PointsAreOnHorizontalOrVerticalLine(pointA, pointB))
        {
            AddHorizontalOrVerticalLineToDictionary(pointA, pointB);
        }
        else if(PointsAreOnDiagonalLine(pointA, pointB))
        {
            AddDiagonalLineToDictionary(pointA, pointB);
        }
    }

    public int GetOverlappingPointsCount()
    {
        int count = 0;
        foreach (var values in _lineDictionary.Values)
        {
            if (values >= 2)
            {
                count++;
            }
        }

        return count;
    }

    private void AddHorizontalOrVerticalLineToDictionary(Point pointA, Point pointB)
    {
        if (pointA.XCoord == pointB.XCoord)
        {
            int startingYCoord = Math.Min(pointA.YCoord, pointB.YCoord);
            int endingYCoord = Math.Max(pointA.YCoord, pointB.YCoord);


            while (startingYCoord <= endingYCoord)
            {
                var newPoint = new Point(pointA.XCoord, startingYCoord);

                if (_lineDictionary.ContainsKey(newPoint))
                {
                    _lineDictionary[newPoint]++;
                }
                else
                {
                    _lineDictionary.Add(newPoint, 1);
                }

                startingYCoord++;
            }
        }
        else if (pointA.YCoord == pointB.YCoord)
        {
            int startingXCoord = Math.Min(pointA.XCoord, pointB.XCoord);
            int endingXCoord = Math.Max(pointA.XCoord, pointB.XCoord);


            while (startingXCoord <= endingXCoord)
            {
                var newPoint = new Point(startingXCoord, pointA.YCoord);

                if (_lineDictionary.ContainsKey(newPoint))
                {
                    _lineDictionary[newPoint]++;
                }
                else
                {
                    _lineDictionary.Add(newPoint, 1);
                }

                startingXCoord++;
            }
        }
    }

    private void AddDiagonalLineToDictionary(Point pointA, Point pointB)
    {
        int xCoordAddition = 0;
        int yCoordAddition = 0;

        if(pointA.XCoord < pointB.XCoord)
        {
            xCoordAddition = 1;
        }
        else if( pointA.XCoord > pointB.XCoord)
        {
            xCoordAddition = -1;
        }

        if (pointA.YCoord < pointB.YCoord)
        {
            yCoordAddition = 1;
        }
        else if (pointA.YCoord > pointB.YCoord)
        {
            yCoordAddition = -1;
        }

        var startingXCoord = pointA.XCoord;
        var startingYCoord = pointA.YCoord;

        
        while(true)
        {
            var newPoint = new Point(startingXCoord, startingYCoord);

            if (_lineDictionary.ContainsKey(newPoint))
            {
                _lineDictionary[newPoint]++;
            }
            else
            {
                _lineDictionary.Add(newPoint, 1);
            }

            if (startingXCoord == pointB.XCoord && startingYCoord == pointB.YCoord)
            {
                break;
            }

            startingXCoord += xCoordAddition;
            startingYCoord += yCoordAddition;
        }
    }

    private bool PointsAreOnHorizontalOrVerticalLine(Point pointA, Point pointB)
    {
        return pointA.XCoord == pointB.XCoord || pointA.YCoord == pointB.YCoord;
    }

    private bool PointsAreOnDiagonalLine(Point pointA, Point pointB)
    {
        var lineRise = Math.Abs(pointB.YCoord - pointA.YCoord);
        var lineRun = Math.Abs(pointB.XCoord - pointA.XCoord);

        var slope = lineRise / lineRun;

        return slope == 1;
    }
}

