using Day6_LanternFish;

var internalTimers = File.ReadAllText("input.txt");

var timerList = internalTimers.Split(",").Select(x => Convert.ToInt32(x)).ToList();

SolvePartTwo(timerList.ToArray());

void SolvePartTwo(int[] input)
{
    long[] fishGeneration = new long[9];
    foreach (int i in input)
    {
        fishGeneration[i]++;
    }

    for (int iteration = 0; iteration < 4; iteration++)
    {
        long newOnes = fishGeneration[0];
        for (int i = 1; i < fishGeneration.Length; i++)
        {
            fishGeneration[i - 1] = fishGeneration[i];
        }

        fishGeneration[8] = newOnes;
        fishGeneration[6] += newOnes;
    }

    Console.Write(fishGeneration.Sum());
}