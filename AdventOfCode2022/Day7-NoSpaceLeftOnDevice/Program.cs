using Day7_NoSpaceLeftOnDevice;
using System.Text;

var terminalOutput = File.ReadAllLines("input.txt");

var elvenComputer = new ElvenComputer();
var commands = new List<string>();

void BuildCommands()
{
    int index = 0;
    for(int i = index;i < terminalOutput.Length; i++, index++)
    {
        var terminalOutputArray = terminalOutput[i].Split(" ");

        if (terminalOutputArray[0] == "$")
        {
            if (terminalOutputArray[1] == "cd")
            {
                commands.Add(terminalOutput[i]);
            }

            else if(terminalOutputArray[1] == "ls")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(terminalOutput[i]);
                sb.Append("\n");

                index += 1;
                while (terminalOutput[index][0] != '$')
                {
                    sb.Append(terminalOutput[index]);
                    index += 1;

                    if(index > terminalOutput.Length - 1)
                    {
                        break;
                    }
                    sb.Append("\n");
                }

                index -= 1;
                i = index;

                commands.Add(sb.ToString());
            }
        }
    }
}

void ExecuteCommands()
{
    foreach(var command in commands)
    {
        var count = command.Split("\n").Length;

        if(count == 1)
        {
            var commandArray = command.Split(" ");

            if (commandArray[1] == "cd")
            {
                if(commandArray[2] == "..")
                {
                    elvenComputer.GoBackOneLevelInDirectory();
                }
                else
                {
                    elvenComputer.ChangeDirectory(commandArray[2]);
                }
            }
        }
        else if(count > 1)
        {
            var allCommands = command.Split("\n");

            var firstCommand = allCommands[0];

            var commandArray = firstCommand.Split(" ");

            if (commandArray[1] == "ls")
            {
                for(int i = 1; i < allCommands.Length; i++)
                {
                    if (allCommands[i] == string.Empty)
                    {
                        continue;
                    }

                    var currentCommandArray = allCommands[i].Split(" ");

                    if (currentCommandArray[0] == "dir")
                    {
                        elvenComputer.CreateDirectory(currentCommandArray[1]);
                    }
                    else
                    {
                        elvenComputer.AddFileToDirectory(currentCommandArray[1], long.Parse(currentCommandArray[0]));
                    }
                }
            }
        }
    }
}


void PrintSumOfDirectoriesWithSizeLessThan(long size)
{
    var directories = elvenComputer.GetDirectoryDictionary();

    long totalSum = 0;

    foreach(var directory in directories.Values)
    {
        long sum = 0;

        foreach(var data in directory.directoryDataDictionary.Values)
        {
            sum += data;
        }

        long SubDirectorySum = 0;
        sum += GetSumOfAllSubDirectories(directory, SubDirectorySum);

        if (sum <= size)
        {
            totalSum += sum;
        }
    }

    Console.WriteLine(totalSum);
}

long GetSumOfAllSubDirectories(DirectoryNode directoryNode, long sum)
{
    if(directoryNode == null)
    {
        return 0;
    }

    foreach(var directory in directoryNode.directoryNodes)
    {
        foreach(var data in directory.directoryDataDictionary.Values)
        {
            sum += data;
        }

        sum = GetSumOfAllSubDirectories(directory, sum);
    }

    return sum;
}

BuildCommands();
ExecuteCommands();
PrintSumOfDirectoriesWithSizeLessThan(100000);