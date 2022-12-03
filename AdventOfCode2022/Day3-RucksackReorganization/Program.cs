var rucksacks = File.ReadAllLines("input.txt");

const int UPPERCASE_A_ASCII = 97;
const int UPPERCASE_Z_ASCII = 122;

void PrintPirorityPartOne()
{
    int priority = 0;
    foreach(var rucksack in rucksacks)
    {
        var rucksackSize = rucksack.Length / 2;

        var rucksackOne = rucksack.Substring(0, rucksackSize);
        var rucksackTwo = rucksack.Substring(rucksackSize, rucksackSize);

        var rucksackList = new List<string>();

        rucksackList.Add(rucksackOne);
        rucksackList.Add(rucksackTwo);

        var commonChar = GetCommonCharacterBetweenRucksacks(rucksackList);

        priority += GetRucksackPriority(commonChar);
    }

    Console.WriteLine(priority);
}

void PrintPriorityPartTwo()
{
    int priority = 0;
    
    for(int i = 0;i < rucksacks.Length; i+= 3)
    {
        var rucksackList = new List<string>();
        for (int j = i; j < i + 3; j++)
        {
            rucksackList.Add(rucksacks[j]);
        }

        var commonChar = GetCommonCharacterBetweenRucksacks(rucksackList);
        priority += GetRucksackPriority(commonChar);
    }

    Console.WriteLine(priority);
}


char GetCommonCharacterBetweenRucksacks(List<string> rucksacks)
{
    var hashSetList = new List<HashSet<char>>();
    
    foreach(var rucksack in rucksacks)
    {
        hashSetList.Add(rucksack.ToHashSet<char>());
    }

    
    for(int i = 0;i < hashSetList.Count; i++)
    {
        hashSetList[0].IntersectWith(hashSetList[i]);
    }

    return hashSetList[0].FirstOrDefault();
}


int GetRucksackPriority(char c)
{
    int rucksackAsciiValue = (int)c;

    int priority = 0;

    if (rucksackAsciiValue >= UPPERCASE_A_ASCII && rucksackAsciiValue <= UPPERCASE_Z_ASCII)
    {
        priority += rucksackAsciiValue - 96;
    }
    else
    {
        priority += rucksackAsciiValue - 38;
    }

    return priority;
}


PrintPirorityPartOne();
PrintPriorityPartTwo();