var allCalories = File.ReadAllLines("input.txt");

var sortedDictionary = new SortedDictionary<int, int>();


void BuildSortedCalorieDictionary()
{
    var list = new List<int>();
    list.Add(0);

    foreach (var c in allCalories)
    {
        var listSize = list.Count - 1;
        var currentCalorieSum = list[listSize];

        if (c == string.Empty)
        {
            sortedDictionary.Add(list[listSize], listSize);
            list.Add(0);
            continue;
        }

        list[listSize] += Int32.Parse(c);
    }

    sortedDictionary.Add(list[list.Count - 1], list.Count - 1);
}

int GetTotalCaloriesForTopK(int k)
{
    int total = 0;

    foreach (var calories in sortedDictionary.Reverse())
    {
        total += calories.Key;
        k--;
        if (k == 0)
        {
            break;
        }
    }

    return total;
}

BuildSortedCalorieDictionary();
Console.WriteLine(GetTotalCaloriesForTopK(1));
Console.WriteLine(GetTotalCaloriesForTopK(3));