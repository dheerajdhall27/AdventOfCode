

var depths = File.ReadAllLines("input.txt");

List<int> depthsList = depths.Select(x => Int32.Parse(x)).ToList();

int numberOfTimesDepthIncreases = 0;

// Solution for the first part
for (int i = 1; i < depthsList.Count(); i++)
{
    if (depthsList[i] > depthsList[i - 1])
    {
        numberOfTimesDepthIncreases++;
    }
}

Console.WriteLine(numberOfTimesDepthIncreases);


int depthIncreaseThreeSum = 0;

// Solution for the second part
for (int i = 1; i < depthsList.Count() - 2; i++)
{
    int firstWindowSum = depthsList[i - 1] + depthsList[i] + depthsList[i + 1];
    int secondWindowSum = depthsList[i] + depthsList[i + 1] + depthsList[i + 2];

    if (secondWindowSum > firstWindowSum)
    {
        depthIncreaseThreeSum++;
    }
}

Console.WriteLine(depthIncreaseThreeSum);