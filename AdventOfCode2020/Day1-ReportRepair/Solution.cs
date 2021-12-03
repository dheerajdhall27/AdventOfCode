

var expenses = File.ReadAllLines("input.txt");

var expensesDictionary = expenses.Select(x => Int32.Parse(x)).ToDictionary<int, int>(x => x);

// Solution to the first part
long result = 0;
foreach (var (key, value) in expensesDictionary)
{
    if (expensesDictionary.ContainsKey(2020 - key))
    {
        result = (2020 - key) * key;
        break;
    }
}

Console.WriteLine(result);

// Solution to the second part
result = 0;

for(int i = 0;i < expensesDictionary.Count; i++)
{
    KeyValuePair<int, int> kvp = expensesDictionary.ElementAt(i);

    bool found = false;
    for (int j = i + 1; j < expensesDictionary.Count; j++)
    {
        KeyValuePair<int, int> kvp2 = expensesDictionary.ElementAt(j);

        int remainder = 2020 - kvp.Key;

        if (expensesDictionary.ContainsKey(remainder - kvp2.Key))
        {
            result = kvp.Key * (remainder - kvp2.Key) * kvp2.Key;
            found = true;
            break;
        }
    }

    if (found) break;
}

Console.WriteLine(result);