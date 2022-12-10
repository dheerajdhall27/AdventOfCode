namespace Day7_NoSpaceLeftOnDevice;

public class DirectoryNode : IEquatable<DirectoryNode>
{
    public DirectoryNode? parent;

    public List<DirectoryNode> directoryNodes;

    public Dictionary<string, long> directoryDataDictionary;

    public string directoryName;

    public DirectoryNode(DirectoryNode? parent, string directoryName)
    {
        this.parent = parent;
        this.directoryNodes = new List<DirectoryNode>();
        this.directoryDataDictionary = new Dictionary<string, long>();
        this.directoryName = directoryName;
    }

    public void AddFileDataToDirectoryDictionary(string fileName, long fileSize)
    {
        if (directoryDataDictionary.ContainsKey(fileName))
        {
            directoryDataDictionary[fileName] = fileSize;
        }
        else
        {
            directoryDataDictionary.Add(fileName, fileSize);
        }
    }

    public bool Equals(DirectoryNode? other)
    {
        if((other == null) || !GetType().Equals(other.GetType()))
        {
            return false;
        }

        DirectoryNode node = other as DirectoryNode;

        if(parent == null && other.parent == null)
        {
            return directoryName.Equals(node.directoryName);
        }
        else if(parent == null && other.parent != null)
        {
            return false;
        }

        return directoryName.Equals(node.directoryName) && parent.Equals(other.parent);
    }

    public override int GetHashCode()
    {
        int hashCode = directoryName.GetHashCode();
        return directoryName.GetHashCode();
    }
}
