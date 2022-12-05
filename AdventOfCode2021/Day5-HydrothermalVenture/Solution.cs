using Day5_HydrothermalVenture;

var lines = File.ReadAllLines("input.txt");


void PrintPartOne()
{
    var hydrothermalVent = new HydrothermalVent();

    foreach (var line in lines)
    {
        var coords = line.Split(" -> ");

        var pointACoords = coords[0].Split(",");
        var pointBCoords = coords[1].Split(",");

        var pointA = CreatePoint(pointACoords[0], pointACoords[1]);
        var pointB = CreatePoint(pointBCoords[0], pointBCoords[1]);

        hydrothermalVent.AddLineToDictionaryPartOne(pointA, pointB);
    }

    int count = hydrothermalVent.GetOverlappingPointsCount();

    Console.WriteLine(count);
}

void PrintPartTwo()
{
    var hydrothermalVent = new HydrothermalVent();

    foreach (var line in lines)
    {
        var coords = line.Split(" -> ");

        var pointACoords = coords[0].Split(",");
        var pointBCoords = coords[1].Split(",");

        var pointA = CreatePoint(pointACoords[0], pointACoords[1]);
        var pointB = CreatePoint(pointBCoords[0], pointBCoords[1]);

        hydrothermalVent.AddLineToDictionary(pointA, pointB);
    }

    int count = hydrothermalVent.GetOverlappingPointsCount();

    Console.WriteLine(count);
}

Point CreatePoint(string x, string y)
{
    int xCoord = Int32.Parse(x);
    int yCoord = Int32.Parse(y);

    return new Point(xCoord, yCoord);
}

PrintPartOne();
PrintPartTwo();






