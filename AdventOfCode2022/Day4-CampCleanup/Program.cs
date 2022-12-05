using Day4_CampCleanup;

var assignmentPairs = File.ReadAllLines("input.txt");

var assignmentPairList = new List<Tuple<AssignmentPair, AssignmentPair>>();
foreach(var assignmentPair in assignmentPairs)
{
    var assignments = assignmentPair.Split(",");

    var assignmentOneValues = assignments[0].Split("-");
    var assignmentTwoValues = assignments[1].Split("-");

    var assignmentA = new AssignmentPair(Int32.Parse(assignmentOneValues[0]), Int32.Parse(assignmentOneValues[1]));
    var assignmentB = new AssignmentPair(Int32.Parse(assignmentTwoValues[0]), Int32.Parse(assignmentTwoValues[1]));

    assignmentPairList.Add(Tuple.Create(assignmentA, assignmentB));
}

int GetNumberOfOverlappingPairPartOne()
{
    int numberOfOVerlappingPairs = 0;

    foreach(var assignmentPair in assignmentPairList)
    {
        var assignmentALow = assignmentPair.Item1.assignmentFrom;
        var assignmentAHigh = assignmentPair.Item1.assignmentTo;

        var assignmentBLow = assignmentPair.Item2.assignmentFrom;
        var assignmentBHigh = assignmentPair.Item2.assignmentTo;

        if(assignmentALow >= assignmentBLow && assignmentAHigh <= assignmentBHigh)
        {
            numberOfOVerlappingPairs++;
        }
        else if(assignmentBLow >= assignmentALow && assignmentBHigh <= assignmentAHigh)
        {
            numberOfOVerlappingPairs++;
        }
    }

    return numberOfOVerlappingPairs;
}

int GetNumberOfOverlappingPairsPartTwo()
{
    var numberOfOverlappingPairs = 0;

    foreach(var assignmentPair in assignmentPairList)
    {
        var assignmentALow = assignmentPair.Item1.assignmentFrom;
        var assignmentAHigh = assignmentPair.Item1.assignmentTo;

        var assignmentBLow = assignmentPair.Item2.assignmentFrom;
        var assignmentBHigh = assignmentPair.Item2.assignmentTo;

        if(assignmentALow >= assignmentBLow && assignmentALow <= assignmentBHigh)
        {
            numberOfOverlappingPairs++;
        }

        else if (assignmentAHigh >= assignmentBLow && assignmentAHigh <= assignmentBHigh)
        {
            numberOfOverlappingPairs++;
        }

        else if (assignmentBLow >= assignmentALow && assignmentBLow <= assignmentAHigh)
        {
            numberOfOverlappingPairs++;
        }

        else if (assignmentBHigh >= assignmentALow && assignmentBHigh <= assignmentAHigh)
        {
            numberOfOverlappingPairs++;
        }
    }

    return numberOfOverlappingPairs;
}

Console.WriteLine(GetNumberOfOverlappingPairPartOne());
Console.WriteLine(GetNumberOfOverlappingPairsPartTwo());