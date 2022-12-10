using Day11_DumboOctopus;

var octopusesRow = File.ReadAllLines("input.txt");

var octopusGrid = new List<List<int>>();

void BuildOctopusGrid()
{
    foreach(var octopusRow in octopusesRow)
    {
        var list = octopusRow.Select(x => int.Parse(x.ToString())).ToList();

        octopusGrid.Add(list);
    }
}


int GetTotalFlashesInKIterationsFloodFill(int iterations)
{
    int flashes = 0;
    for(int i = 0; i < iterations; i++)
    {
        PrintGrid();
        Console.WriteLine("\n\n");

        var octopusFlashedSet = new HashSet<Octopus>();
        for (int y = 0; y < octopusGrid.Count; y++)
        {
            for(int x = 0; x < octopusGrid[0].Count;x++)
            {
                int value = octopusGrid[y][x];

                value += 1;
                if(value == 10)
                {
                    var octopusFlashed = new Octopus(y, x);
                    octopusFlashedSet.Add(octopusFlashed);
                    octopusGrid[y][x] = 0;
                    flashes += GetOctopusFlashesAroundCoordinates(y, x, octopusFlashedSet);
                }
                else
                {
                    octopusGrid[y][x] = value;
                }
            }
        }
    }

    return flashes;
}

void PrintGrid()
{
    foreach(var list in octopusGrid)
    {
        foreach(var element in list)
        {
            Console.Write(element);
        }
        Console.WriteLine();
    }
}

int GetOctopusFlashesAroundCoordinates(int y, int x, HashSet<Octopus> octopusFlashedSet)
{
    int flashes = 1;
    var stack = new Stack<Octopus>();

    var octopusFlashed = new Octopus(y, x);
    stack.Push(octopusFlashed);


    while(stack.Count > 0)
    {
        var octopus = stack.Pop();

        var neighbors = GetAllNeighborsOfCoordinate(octopus.row, octopus.col);

        foreach(var neighbor in neighbors)
        {
            var newOctopus = new Octopus(neighbor.row, neighbor.col);
            if(octopusFlashedSet.Contains(newOctopus))
            {
                continue;
            }

            int value = octopusGrid[neighbor.row][neighbor.col];

            value++;

            if (value == 10)
            {
                flashes++;
                octopusGrid[neighbor.row][neighbor.col] = 0;

                stack.Push(newOctopus);
                octopusFlashedSet.Add(newOctopus);
            }
            else
            {
                octopusGrid[neighbor.row][neighbor.col] = value;
            }    
        }
    }

    return flashes;
}


List<Octopus> GetAllNeighborsOfCoordinate(int yCoord, int xCoord)
{
    var neighbors = new List<Octopus>();

    for(int y = -1; y <= 1; y++)
    {
        for(int x = -1; x <= 1; x++)
        {
            if(x == 0 && y == 0)
            {
                continue;
            }

            var neighborRow = yCoord + y;
            var neighborCol = xCoord + x;

            if(neighborRow < 0 || neighborRow > octopusGrid.Count - 1 ||
               neighborCol < 0 || neighborCol > octopusGrid[0].Count - 1)
            {
                continue;
            }

            var octopus = new Octopus(neighborRow, neighborCol);
            neighbors.Add(octopus);
        }
    }

    return neighbors;
}

BuildOctopusGrid();
Console.WriteLine(GetTotalFlashesInKIterationsFloodFill(100));
