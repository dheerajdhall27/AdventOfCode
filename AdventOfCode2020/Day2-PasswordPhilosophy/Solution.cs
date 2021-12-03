using System.Linq;
using System.Text.RegularExpressions;

var passwordData = File.ReadAllLines("input.txt");

var passwordDictionary = passwordData.Select(x => (x.Split(':')[0], x.Split(':')[1]));

// Solution to the first part
int validPasswordCount = 0;

foreach (var passwordPolicy in passwordDictionary)
{

    string policy = passwordPolicy.Item1.Trim();
    string password = passwordPolicy.Item2.Trim();

    int min = Int32.Parse(policy.Split(' ')[0].Split('-')[0]);
    int max = Int32.Parse(policy.Split(' ')[0].Split('-')[1]);

    char c = policy.Split(' ')[1][0];

    string pattern = $"{c}";

    Regex regex = new Regex(pattern);

    int total = regex.Matches(password).Count();
    
    if (total >= min && total <= max) 
    { 
        validPasswordCount++;
    }
}

Console.WriteLine(validPasswordCount);

// Solution to the second part
validPasswordCount = 0;

foreach(var passwordPolicy in passwordDictionary)
{
    string policy = passwordPolicy.Item1.Trim();
    string password = passwordPolicy.Item2.Trim();

    int firstPos = Int32.Parse(policy.Split(' ')[0].Split('-')[0]) - 1;
    int secondPos = Int32.Parse(policy.Split(' ')[0].Split('-')[1]) - 1;

    char c = policy.Split(' ')[1][0];
    
    if ((password.ElementAt(firstPos) == c && password.ElementAt(secondPos) != c) ||
        (password.ElementAt(firstPos) != c && password.ElementAt(secondPos) == c))
    {
        validPasswordCount++;
    }
}

Console.WriteLine(validPasswordCount);