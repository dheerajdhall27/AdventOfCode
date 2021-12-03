

var expenses = File.ReadAllLines("input.txt");

var expensesHashset = expenses.Select(x => Int32.Parse(x)).ToHashSet<int>();

// Solution to the first part
long result = 0;
foreach (var value in expensesHashset)
{
    if (expensesHashset.Contains(2020 - value))
    {
        result = (2020 - value) * value;
        break;
    }
}

Console.WriteLine(result);

// Solution to the second part
result = 0;

for(int i = 0; i < expensesHashset.Count; i++)
{
    int value = expensesHashset.ElementAt(i);

    bool found = false;
    for (int j = i + 1; j < expensesHashset.Count; j++)
    {
        int value2 = expensesHashset.ElementAt(j);

        int remainder = 2020 - value;

        if (expensesHashset.Contains(remainder - value2))
        {
            result = value * (remainder - value2) * value2 ;
            found = true;
            break;
        }
    }

    if (found) break;
}

Console.WriteLine(result);