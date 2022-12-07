var octopusesRow = File.ReadAllLines("input.txt");

var octopusGrid = new List<List<int>>();

void BuildOctopusGrid()
{
    foreach(var octopusRow in octopusesRow)
    {
        var list = octopusesRow.Select(x => int.Parse(x)).ToList();

        octopusGrid.Add(list);
    }
}


int GetTotalFlashesInKIterationsFloodFill(int iterations)
{
    int flashes = 0;
    for(int i = 0;i < iterations; i++)
    {
        for(int row = 0;row < octopusGrid.Count; row++)
        {
            for(int column = 0; column < octopusGrid[i].Count;column++)
            {
                int value = octopusGrid[row][column];

                value += 1;
                if(value == 10)
                {
                    octopusGrid[row][column] = 0;
                    GetOctopusFlashesAroundCoordinates(row, column);
                }
                else
                {
                    octopusGrid[row][column] = value;
                }
            }
        }
    }

    return flashes;
}

int GetOctopusFlashesAroundCoordinates(int x, int y)
{
    int flashes = 0;
    var stack = new Stack<(int, int)>();

    return flashes;
}


List<(int, int)> GetAllNeighborsOfCoordinate(int x, int y)
{

}

BuildOctopusGrid();
Console.WriteLine(GetTotalFlashesInKIterationsFloodFill(100));