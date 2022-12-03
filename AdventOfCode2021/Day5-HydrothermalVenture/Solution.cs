using Day5_HydrothermalVenture;

var lines = File.ReadAllLines("input.txt");


var pointDictionary = new Dictionary<Point, int>();



foreach(var line in lines)
{
    var coords = line.Split(" -> ");

    var pointACoords = coords[0].Split(",");
    var pointBCoords = coords[1].Split(",");

    var pointA = CreatePoint(pointACoords[0], pointACoords[1]);
    var pointB = CreatePoint(pointBCoords[0], pointBCoords[1]);

    if(PointsAreOnHorizontalOrVerticalLine(pointA, pointB))
    {
        AddAllPointsOnLineToDictionary(pointA, pointB);
    }
}

int count = 0;
foreach (var values in pointDictionary.Values)
{
    if (values >= 2)
    {
        count++;
    }
}

Console.WriteLine(count);

Point CreatePoint(string x, string y)
{
    int xCoord = Int32.Parse(x);
    int yCoord = Int32.Parse(y);

    return new Point(xCoord, yCoord);
}

bool PointsAreOnHorizontalOrVerticalLine(Point pointA, Point pointB)
{
    return pointA.XCoord == pointB.XCoord || pointA.YCoord == pointB.YCoord;
}

void AddAllPointsOnLineToDictionary(Point pointA, Point pointB)
{
    if (pointA.XCoord == pointB.XCoord)
    {
        bool isPointAYCoordGreater = pointA.YCoord >= pointB.YCoord;

        int startingYCoord = pointB.YCoord;
        int endingYCoord = pointA.YCoord;

        if (isPointAYCoordGreater)
        {
            startingYCoord = pointA.YCoord;
            endingYCoord = pointB.YCoord;
        }

        while (startingYCoord >= endingYCoord)
        {
            var newPoint = new Point(pointA.XCoord, startingYCoord);

            if (pointDictionary.ContainsKey(newPoint))
            {
                pointDictionary[newPoint]++;
            }
            else
            {
                pointDictionary.Add(newPoint, 1);
            }

            startingYCoord--;
        }
    }
    else if (pointA.YCoord == pointB.YCoord)
    {
        bool isPointAXCoordGreater = pointA.XCoord >= pointB.XCoord;

        int startingXCoord = pointB.XCoord;
        int endingXCoord = pointA.XCoord;

        if (isPointAXCoordGreater)
        {
            startingXCoord = pointA.XCoord;
            endingXCoord = pointB.XCoord;
        }

        while (startingXCoord >= endingXCoord)
        {
            var newPoint = new Point(startingXCoord, pointA.YCoord);

            if (pointDictionary.ContainsKey(newPoint))
            {
                pointDictionary[newPoint]++;
            }
            else
            {
                pointDictionary.Add(newPoint, 1);
            }

            startingXCoord--;
        }
    }
}


