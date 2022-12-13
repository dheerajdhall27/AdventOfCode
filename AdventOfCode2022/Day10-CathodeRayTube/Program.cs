var signalData = File.ReadAllLines("input.txt");

var signalStrengthDictionary = new Dictionary<int, long>();

void PrintPartOne()
{
    var cycleArray = new int[] { 20, 60, 100, 140, 180, 220 };

    long register = 1;
    int cycle = 0;

    foreach (var signal in signalData)
    {
        var signalValues = signal.Split(" ");

        if (signalValues[0] == "addx")
        {
            cycle += 1;
            signalStrengthDictionary.Add(cycle, cycle * register);


            cycle += 1;
            signalStrengthDictionary.Add(cycle, cycle * register);
            register += int.Parse(signalValues[1]);
        }
        else
        {
            cycle += 1;
            signalStrengthDictionary.Add(cycle, cycle * register);
        }
    }

    long total = 0;
    for (int i = 0; i < cycleArray.Length; i++)
    {
        if (signalStrengthDictionary.ContainsKey(cycleArray[i]))
        {
            total += signalStrengthDictionary[cycleArray[i]];
        }
    }

    Console.WriteLine(total);
}


void PrintPartTwo()
{
    var crt = new char[6, 40];

    var spritePosition = new char[40];

    RearrangeSpritePosition(spritePosition);

    int row = 0;
    int col = 0;

    int register = 1;

    foreach (var signal in signalData)
    {
        var signalValues = signal.Split(" ");

        if (signalValues[0] == "addx")
        {
            crt[row, col] = spritePosition[col] == '#' ? '#' : '.';
            col += 1;

            if (col > 39)
            {
                col = 0;
                row++;
                RearrangeSpritePosition(spritePosition);
            }

            crt[row, col] = spritePosition[col] == '#' ? '#' : '.';
            col += 1;

            if (col > 39)
            {
                col = 0;
                row++;
                RearrangeSpritePosition(spritePosition);
            }

            register += int.Parse(signalValues[1]);
        }
        else
        {
            crt[row, col] = spritePosition[col] == '#' ? '#' : '.';
            col += 1;
            if (col > 39)
            {
                col = 0;
                row++;
                RearrangeSpritePosition(spritePosition);
            }
        }

        ArrangeSpritePositionBasedOnRegister(spritePosition, register);
    }

    for (int i = 0; i < crt.GetLength(0); i++)
    {
        for(int j = 0; j < crt.GetLength(1); j++)
        {
            Console.Write(crt[i, j]);
        }
        Console.WriteLine();
    }
}

void RearrangeSpritePosition(char[] spritePosition)
{
    for(int i = 0;i < spritePosition.Length; i++)
    {
        spritePosition[i] = ' ';
    }

    spritePosition[0] = '#';
    spritePosition[1] = '#';
    spritePosition[2] = '#';
}

void ArrangeSpritePositionBasedOnRegister(char[] spritePosition, int register)
{
    for (int i = 0; i < spritePosition.Length; i++)
    {
        spritePosition[i] = ' ';
    }

    if (register < 0) return;

    spritePosition[register - 1] = '#';
    spritePosition[register] = '#';
    spritePosition[register + 1] = '#';
}

PrintPartOne();
PrintPartTwo();