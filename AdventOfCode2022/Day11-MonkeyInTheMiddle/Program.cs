using Day11_MonkeyInTheMiddle;
using System.Text;

var monkeyNotes = File.ReadAllLines("input.txt");

var monkeys = new List<string>();

var stringBuilder = new StringBuilder();
foreach (var monkey in monkeyNotes)
{    
    if(monkey == "")
    {
        monkeys.Add(stringBuilder.ToString());
        stringBuilder.Clear();
        continue;
    }

    stringBuilder.Append(monkey.Trim());
    stringBuilder.Append("\n");
}

monkeys.Add(stringBuilder.ToString());

var monkeyDictionary = new Dictionary<int, Monkey>();

foreach(var monkeyData in monkeys)
{
    var data = monkeyData.Split("\n");

    int monkeyNumber = int.Parse(data[0].Split(" ")[1].Split(":")[0]);
    List<long> startingItems = data[1].Split(":")[1].Trim().Split(", ").Select(x => long.Parse(x)).ToList();
    string operation = data[2].Split("=")[1].Trim().Split(" ")[1];
    string operandValue = data[2].Split("=")[1].Trim().Split(" ")[2];
    int divisibleBy = int.Parse(data[3].Split("by")[1].Trim());
    int throwToMonkeyTrue = int.Parse(data[4].Split("monkey")[1].Trim());
    int throwToMonkeyFalse = int.Parse(data[5].Split("monkey")[1].Trim());

    var monkey = new Monkey(startingItems, operation, divisibleBy, operandValue, throwToMonkeyTrue, throwToMonkeyFalse);

    monkeyDictionary.Add(monkeyNumber, monkey);
}


void PrintPartOne()
{
    var monkeyArr = new long[monkeyDictionary.Count];
    for (int i = 0; i < 1001; i++)
    {
        if (i == 1000)
        {
            Console.WriteLine();
        }
        foreach (var monkeyNumber in monkeyDictionary.Keys)
        {
            var monkey = monkeyDictionary[monkeyNumber];

            foreach (var item in monkey.items)
            {
                long value = 0;
                if (monkey.operation == "*")
                {
                    if (monkey.operandValue == "old")
                    {
                        value = item * item;
                    }
                    else
                    {
                        value = item * int.Parse(monkey.operandValue);
                    }
                }

                else if (monkey.operation == "+")
                {
                    if (monkey.operandValue == "old")
                    {
                        value = item + item;
                    }
                    else
                    {
                        value = item + int.Parse(monkey.operandValue);
                    }
                }

                //value = value * 3;

                if (value % monkey.divisibleBy == 0)
                {
                    monkeyDictionary[monkey.throwToMonkeyTrue].items.Add(value);
                }
                else
                {
                    monkeyDictionary[monkey.throwToMonkeyFalse].items.Add(value);
                }
            }

            monkeyArr[monkeyNumber] += monkey.items.Count;

            monkeyDictionary[monkeyNumber].items.Clear();
        }
    }

    Array.Sort(monkeyArr);

    Console.WriteLine(monkeyArr[monkeyArr.Length - 1] * monkeyArr[monkeyArr.Length - 2]);
}

void PrintPartTwo()
{
    var mod = 1;
    foreach(var monkeyNumber in monkeyDictionary.Keys)
    {
        mod *= monkeyDictionary[monkeyNumber].divisibleBy;
    }

    var monkeyArr = new long[monkeyDictionary.Count];
    for (int i = 0; i < 10000; i++)
    {
        foreach (var monkeyNumber in monkeyDictionary.Keys)
        {
            var monkey = monkeyDictionary[monkeyNumber];

            foreach (var item in monkey.items)
            {
                long value = 0;
                if (monkey.operation == "*")
                {
                    if (monkey.operandValue == "old")
                    {
                        value = item * item;
                    }
                    else
                    {
                        value = item * int.Parse(monkey.operandValue);
                    }
                }

                else if (monkey.operation == "+")
                {
                    if (monkey.operandValue == "old")
                    {
                        value = item + item;
                    }
                    else
                    {
                        value = item + int.Parse(monkey.operandValue);
                    }
                }

                value = value % mod;

                if (value % monkey.divisibleBy == 0)
                {
                    monkeyDictionary[monkey.throwToMonkeyTrue].items.Add(value);
                }
                else
                {
                    monkeyDictionary[monkey.throwToMonkeyFalse].items.Add(value);
                }
            }

            monkeyArr[monkeyNumber] += monkey.items.Count;

            monkeyDictionary[monkeyNumber].items.Clear();
        }
    }

    Array.Sort(monkeyArr);

    Console.WriteLine(monkeyArr[monkeyArr.Length - 1] * monkeyArr[monkeyArr.Length - 2]);
}

//PrintPartOne();

PrintPartTwo();

//Monkey 0 inspected items 99 times.
//Monkey 1 inspected items 97 times.
//Monkey 2 inspected items 8 times.
//Monkey 3 inspected items 103 times.