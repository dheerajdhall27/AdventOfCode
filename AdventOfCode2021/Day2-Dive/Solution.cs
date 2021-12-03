
var commands = File.ReadAllLines("input.txt");


var directionDistanceTuple = commands.Select(x => (x.Split(' ')[0], Int32.Parse(x.Split(' ')[1]))).ToList<(string, int)>();

// Solution for the first part
int horizontalDistance = 0;
int verticalDistance = 0;

directionDistanceTuple.ForEach(x =>
{
    if (x.Item1 == "forward")
    {
        horizontalDistance += x.Item2;
    }
    else if (x.Item1 == "down")
    {
        verticalDistance += x.Item2;
    }
    else 
    {
        verticalDistance -= x.Item2;
    }
});

long finalHorizontalTimesVertical = horizontalDistance * verticalDistance;

Console.WriteLine(finalHorizontalTimesVertical);



// Solution for the second part
int aim = 0;
horizontalDistance = 0;
verticalDistance = 0;


directionDistanceTuple.ForEach(x =>
{
    if (x.Item1 == "forward")
    {
        horizontalDistance += x.Item2;
        verticalDistance += aim * x.Item2;
    }
    else if (x.Item1 == "down")
    {
        aim += x.Item2;
    }
    else
    {
        aim -= x.Item2;
    }
});

finalHorizontalTimesVertical = horizontalDistance * verticalDistance;
Console.WriteLine(finalHorizontalTimesVertical);