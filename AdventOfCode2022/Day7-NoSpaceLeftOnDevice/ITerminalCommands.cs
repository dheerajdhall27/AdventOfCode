namespace Day7_NoSpaceLeftOnDevice;

public interface ITerminalCommands
{
    public void CreateDirectory(string directoryName);

    public void ChangeDirectory(string directoryName);

    public void AddFileToDirectory(string fileName, long fileSize);

    public void GoBackOneLevelInDirectory();

    public void ReadFiles();
}
