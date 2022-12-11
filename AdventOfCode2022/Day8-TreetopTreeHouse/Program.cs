using Day8_TreetopTreeHouse;

var treeData = File.ReadAllLines("input.txt");

var outerGridDictionary = new Dictionary<string, int>();

var grid = new List<List<int>>();

void BuildTheGrid()
{
    for(int row = 0;row < treeData.Length; row++)
    {
        List<int> list = new List<int>();
        for (int col = 0; col < treeData[row].Length; col++)
        {
            list.Add(int.Parse(treeData[row][col].ToString()));
        }

        grid.Add(list);
    }
}

void BuildTheOuterDictionary()
{
    // Save the first row
    for(int i = 0; i < treeData[0].Length; i++)
    {
        var coordinate = $"{0}+{i}";
        var treeHeight = int.Parse(treeData[0][i].ToString());

        outerGridDictionary.Add(coordinate, treeHeight);
    }

    // Save the last row
    for (int i = 0; i < treeData[0].Length; i++)
    {
        var coordinate = $"{treeData.Length - 1}+{i}";
        var treeHeight = int.Parse(treeData[treeData.Length - 1][i].ToString());

        outerGridDictionary.Add(coordinate, treeHeight);
    }

    // Add Left Column
    for(int i = 1; i < treeData.Length - 1; i++)
    {
        var coordinate = $"{i}+{0}";
        var treeHeight = int.Parse(treeData[i][0].ToString());

        outerGridDictionary.Add(coordinate, treeHeight);
    }

    // Add Right Column
    for (int i = 1; i < treeData.Length - 1; i++)
    {
        var coordinate = $"{i}+{treeData[0].Length - 1}";
        var treeHeight = int.Parse(treeData[i][treeData[0].Length - 1].ToString());

        outerGridDictionary.Add(coordinate, treeHeight);
    }
    Console.WriteLine();
}

void PrintTotalVisibleTrees()
{
    int visibleTrees = 0;
    for(int row = 1; row < treeData.Length - 1; row++)
    {
        for(int col = 1; col < treeData[row].Length - 1; col++)
        {
            var value = int.Parse(treeData[row][col].ToString());

            var leftPoint = $"{row}+{0}";
            var rightPoint = $"{row}+{treeData[row].Length - 1}";
            var topPoint = $"{0}+{col}";
            var bottomPoint = $"{treeData.Length - 1}+{col}";

            var currentPoint = $"{row}+{col}";

            if (outerGridDictionary[leftPoint] >= value &&
                outerGridDictionary[rightPoint] >= value &&
                outerGridDictionary[topPoint] >= value &&
                outerGridDictionary[bottomPoint] >= value)
            {
                continue;
            }

            else
            {
                int numberOfBlockedSides = 0;
                // Right
                for(int i = col + 1; i < treeData[row].Length; i++)
                {
                    if (grid[row][i] >= value)
                    {
                        numberOfBlockedSides++;
                        break;
                    }
                }

                // Left
                for (int i = col - 1; i >= 0; i--)
                {                    
                    if (grid[row][i] >= value)
                    {
                        numberOfBlockedSides++;
                        break;
                    }
                }

                // Up
                for (int i = row - 1; i >= 0; i--)
                {
                    if (grid[i][col] >= value)
                    {
                        numberOfBlockedSides++;
                        break;
                    }
                }

                // Down
                for (int i = row + 1; i < treeData.Length; i++)
                {
                    if (grid[i][col] >= value)
                    {
                        numberOfBlockedSides++;
                        break;
                    }
                }

                if(numberOfBlockedSides < 4)
                {
                    visibleTrees++;
                }
            }
        }
    }

    Console.WriteLine(visibleTrees + outerGridDictionary.Count);
}


void PrintBestScenicScore()
{
    int max = Int32.MinValue;

    for(int row = 1; row < grid.Count - 1; row++)
    {
        for (int col = 1; col < grid[row].Count - 1; col++)
        {
            var value = grid[row][col];

            int scenicScore = 1;

            int count = 0;
            for (int i = col + 1; i < treeData[row].Length; i++)
            {
                if (grid[row][i] >= value)
                {
                    count++;
                    break;
                }
                count++;
            }

            scenicScore = scenicScore * (count == 0 ? 1 : count);
            count = 0;
            // Left
            for (int i = col - 1; i >= 0; i--)
            {
                if (grid[row][i] >= value)
                {
                    count++;
                    break;
                }
                count++;
            }

            scenicScore = scenicScore * (count == 0 ? 1 : count);
            count = 0;
            // Up
            for (int i = row - 1; i >= 0; i--)
            {
                if (grid[i][col] >= value)
                {
                    count++;
                    break;
                }
                count++;
            }

            scenicScore = scenicScore * (count == 0 ? 1 : count);
            count = 0;
            // Down
            for (int i = row + 1; i < treeData.Length; i++)
            {
                if (grid[i][col] >= value)
                {
                    count++;
                    break;
                }
                count++;
            }

            scenicScore = scenicScore * (count == 0 ? 1 : count);
            max = Math.Max(scenicScore, max);
        }
    }

    Console.WriteLine(max);
}

BuildTheGrid();
BuildTheOuterDictionary();

PrintBestScenicScore();