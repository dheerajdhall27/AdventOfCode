using System.Text;

var crateformation = File.ReadAllLines("input.txt");

var stackInformation = new List<string>();
var rearrangementInformation = new List<string>();

var stackList = new List<List<char>>();

var rearrangementMovesList = new List<List<int>>();

void SplitRearrangementAndStackInformation()
{
    bool storeArrangementInformation = false;
    foreach(var line in crateformation)
    {
        if(line == "")
        {
            storeArrangementInformation = true;
            continue;
        }

        if(storeArrangementInformation)
        {
            rearrangementInformation.Add(line);
        }
        else
        {
            stackInformation.Add(line);
        }
    }
}


void BuildCurrentCrateArrangement()
{
    for (int i = 1; i < stackInformation[0].Length; i += 4)
    {
        stackList.Add(new List<char>());
    }

    foreach (var line in stackInformation)
    {
        if (line == "")
        {
            break;
        }

        for (int i = 1; i < line.Length; i += 4)
        {
            var charToEnqueue = line[i];
            var charToEnqueueAscii = (int)charToEnqueue;

            if (charToEnqueueAscii >= 48 && charToEnqueueAscii <= 57)
            {
                break;
            }

            if (charToEnqueue != ' ')
            {
                stackList[i / 4].Insert(0, charToEnqueue);
            }
        }
    }
}

void BuildRearrangementList()
{  
    foreach(var line in rearrangementInformation)
    {
        var moves = line.Split(" ");

        var movesList = new List<int>();

        movesList.Add(Int32.Parse(moves[1]));
        movesList.Add(Int32.Parse(moves[3]) - 1);
        movesList.Add(Int32.Parse(moves[5]) - 1);

        rearrangementMovesList.Add(movesList);
    }
}

void MoveCratesAndPrintTopCratesPartOne()
{
    foreach(var moves in rearrangementMovesList)
    {
        for(int i = 0;i < moves[0]; i++)
        {
            if (stackList[moves[1]].Count > 0)
            {
                var crateToMove = stackList[moves[1]][stackList[moves[1]].Count - 1];
                stackList[moves[1]].RemoveAt(stackList[moves[1]].Count - 1);
                stackList[moves[2]].Add(crateToMove);
            }
        }
    }

    StringBuilder stringBuilder = new StringBuilder();
    foreach(var stack in stackList)
    {
        stringBuilder.Append(stack[stack.Count - 1]);
    }

    Console.WriteLine(stringBuilder.ToString());
}

void MoveCratesAndPrintTopCratesPartTwo()
{
    foreach (var moves in rearrangementMovesList)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < moves[0]; i++)
        {
            if (stackList[moves[1]].Count > 0)
            {
                var crateToMove = stackList[moves[1]][stackList[moves[1]].Count - 1];
                stackList[moves[1]].RemoveAt(stackList[moves[1]].Count - 1);
                stack.Push(crateToMove);
            }
        }

        while(stack.Count > 0)
        {
            stackList[moves[2]].Add(stack.Pop());
        }
    }

    StringBuilder stringBuilder = new StringBuilder();
    foreach (var stack in stackList)
    {
        stringBuilder.Append(stack[stack.Count - 1]);
    }

    Console.WriteLine(stringBuilder.ToString());
}

SplitRearrangementAndStackInformation();
BuildCurrentCrateArrangement();
BuildRearrangementList();
//MoveCratesAndPrintTopCratesPartOne();
MoveCratesAndPrintTopCratesPartTwo();