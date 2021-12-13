
var horizontalData = File.ReadAllText("input.txt");

var horizontalPositions = horizontalData.Split(",").Select(x => Convert.ToInt32(x)).ToList();

// Solution to part one
int min = int.MaxValue;

for(int i = 0; i < horizontalPositions.Count; i++)
{
    int sum = 0;

    for(int j = 0; j < horizontalPositions.Count; j++)
    {
        if (i == j) continue;

        sum += Math.Abs(horizontalPositions[i] - horizontalPositions[j]);
    }

    min = Math.Min(min, sum);
}

Console.WriteLine(min);



// Solution to part two
min = int.MaxValue;

horizontalPositions.Sort();

for(int i = horizontalPositions[0];i <= horizontalPositions[horizontalPositions.Count - 1]; i++)
{
    int sum = 0;

    for(int j = 0; j < horizontalPositions.Count; j++)
    {
        int move = Math.Abs(horizontalPositions[j] - i);

        int s = move * (move + 1) / 2;
        
        sum += s;
    }

    min = Math.Min(min, sum);
}

Console.WriteLine(min);


