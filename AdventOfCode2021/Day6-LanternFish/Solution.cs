using Day6_LanternFish;

var internalTimers = File.ReadAllText("input.txt");

var timerList = internalTimers.Split(",").Select(x => Convert.ToInt32(x)).ToList();

void SolvePartOne(List<int> input)
{
    for(int i = 0; i < 80; i++)
    {
        int listSize = input.Count;

        for(int j = 0;j < listSize;j++)
        {
            if(input[j] == 0)
            {
                input.Add(8);
                input[j] = 6;
                continue;
            }

            input[j] -= 1;
        }
    }

    Console.WriteLine(input.Count);
}


SolvePartOne(timerList);