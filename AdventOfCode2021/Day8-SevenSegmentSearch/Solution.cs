using Day8_SevenSegmentSearch.SevenSegmentModels;
using System.Configuration;

var sevenSegmentData = File.ReadAllLines("input.txt");

var outputValues = sevenSegmentData.Select(x => x.Split("|")[1].Trim()).ToList();

// Solution to part 1
HashSet<int> uniqueValueHashset = new HashSet<int>()
{
    2, 4, 3, 7
};

int totalUniqueValuesInOutput = 0;
foreach (var values in outputValues)
{
    string[] outputArray = values.Split(" ");

    foreach (var value in outputArray)
    {
        int length = value.Length;

        if (uniqueValueHashset.Contains(length))
        {
            totalUniqueValuesInOutput++;
        }
    }
}

//Console.WriteLine(totalUniqueValuesInOutput);


// Solution to part 2


int total = 0;
foreach(var segmentData in sevenSegmentData)
{
    SevenSegmentDisplay ssd = new SevenSegmentDisplay();
    var allSegments = segmentData.Split("|")[0].Split(" ");
    var output = segmentData.Split("|")[1].Trim().Split(" ");


    ssd.MapAllSegmentToNumbers(allSegments);

    int number = 0;
    int pos = 0;

    for(int i = output.Length - 1; i >= 0; i--)
    {
        var outputSegment = String.Concat(output[i].OrderBy(x => x));
        number += ssd.segmentToNumberDictionary[outputSegment] * (int)Math.Pow(10, pos);
        pos++;
    }

    total += number;

}

Console.WriteLine(total);
