namespace Day7_NoSpaceLeftOnDevice;

public class ElvenComputer : ITerminalCommands
{
    private Dictionary<string, DirectoryNode> _directoryDictionary;

    private DirectoryNode? _currentDirectory;

    private const string ROOT_DIRECTORY = "/";

    public ElvenComputer()
    {
        _directoryDictionary = new Dictionary<string, DirectoryNode>();
        InitializeRootDirectory();
        _currentDirectory = _directoryDictionary.First().Value;
    }

    public Dictionary<string, DirectoryNode> GetDirectoryDictionary()
    {
        return _directoryDictionary;
    }

    public void CreateDirectory(string directoryName)
    {
        if (_currentDirectory is null)
        {
            throw new InvalidProgramException("The Current Directory cannot be null!");
        }

        if(_directoryDictionary.ContainsKey(directoryName))
        {
            return;
        }

        var newDirectory = new DirectoryNode(_currentDirectory, directoryName);

        if (_directoryDictionary.ContainsKey(directoryName))
        {
            throw new ArgumentException("The Directory already exists!");
        }

        _currentDirectory.directoryNodes.Add(newDirectory);
        _directoryDictionary.Add(directoryName, newDirectory);
    }

    public void ChangeDirectory(string directoryName)
    {
        if(_currentDirectory is null)
        {
            throw new InvalidProgramException("The Current Directory cannot be null!");
        }

        if(directoryName is ROOT_DIRECTORY)
        {
            _currentDirectory = _directoryDictionary[ROOT_DIRECTORY];
            return;
        }

        var directoryToChangeTo = _directoryDictionary[directoryName];

        if(directoryToChangeTo is null)
        {
            throw new ArgumentException("The Directory Name passed is invalid!", directoryName);
        }

        foreach(var directory in _currentDirectory.directoryNodes)
        {
            if(directory.Equals(directoryToChangeTo))
            {
                _currentDirectory = directory;
                return;
            }
        }
    }

    public void AddFileToDirectory(string fileName, long fileSize)
    {
        if (_currentDirectory is null)
        {
            throw new InvalidProgramException("The Current Directory cannot be null!");
        }

        _currentDirectory.AddFileDataToDirectoryDictionary(fileName, fileSize);
    }

    public void GoBackOneLevelInDirectory()
    {
        if (_currentDirectory is null)
        {
            throw new InvalidProgramException("The Current Directory cannot be null!");
        }

        var directoryParent = _currentDirectory.parent;

        if(directoryParent == null)
        {
            _currentDirectory = _directoryDictionary[ROOT_DIRECTORY];
            return;
        }

        _currentDirectory = _directoryDictionary[directoryParent.directoryName];
    }

    public void ReadFiles()
    {
        throw new NotImplementedException();
    }

    private void InitializeRootDirectory()
    {
        var rootDirectory = new DirectoryNode(null, ROOT_DIRECTORY);

        _directoryDictionary.Add(rootDirectory.directoryName, rootDirectory);
    }
}
