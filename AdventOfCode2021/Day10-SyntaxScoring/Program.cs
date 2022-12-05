using System.Text;

var chunks = File.ReadLines("input.txt");


var chunkCharDictionary = new Dictionary<char, char>();
var charScoringDictionary = new Dictionary<char, int>();

var incompleteCharScoringDictionary = new Dictionary<char, int>();

void SolvePartOne()
{
    int score = 0;
    foreach(var chunk in chunks)
    {
        var invalidCharacter = GetInvalidCharacterIfAny(chunk);

        if(invalidCharacter != '\0')
        {
            score += charScoringDictionary[invalidCharacter];
        }
    }

    Console.WriteLine(score);
}

void SolvePartTwo()
{
    var list = new List<long>();
    foreach(var chunk in chunks)
    {
        var incompleteStack = GetIncompleteChunk(chunk);

        if(incompleteStack.Count != 0)
        {
            var chunkBuilder = new StringBuilder();

            while(incompleteStack.Count > 0)
            {
                var openingChunk = incompleteStack.Pop();
                chunkBuilder.Append(chunkCharDictionary[openingChunk]);
            }

            var remainingChunk = chunkBuilder.ToString();

            long score = 0;

            foreach(char c in remainingChunk)
            {
                score = score * 5;
                score += incompleteCharScoringDictionary[c];
            }

            list.Add(score);
        }
    }

    list.Sort();
    Console.WriteLine(list[list.Count / 2]);
}

void BuildChunkCharDictionary()
{
    chunkCharDictionary.Add('(', ')');
    chunkCharDictionary.Add('[', ']');
    chunkCharDictionary.Add('{', '}');
    chunkCharDictionary.Add('<', '>');
}

void BuildCharScoreDictionarty()
{
    charScoringDictionary.Add(')', 3);
    charScoringDictionary.Add(']', 57);
    charScoringDictionary.Add('}', 1197);
    charScoringDictionary.Add('>', 25137);

    incompleteCharScoringDictionary.Add(')', 1);
    incompleteCharScoringDictionary.Add(']', 2);
    incompleteCharScoringDictionary.Add('}', 3);
    incompleteCharScoringDictionary.Add('>', 4);
}

char GetInvalidCharacterIfAny(string chunk)
{
    var chars = new Stack<char>();

    for(int i = 0; i < chunk.Length; i++)
    {
        if (chunkCharDictionary.ContainsKey(chunk[i]))
        {
            chars.Push(chunk[i]);
            continue;
        }

        var topChar = chars.Peek();

        if (chunkCharDictionary[topChar] == chunk[i])
        {
            chars.Pop();
        }
        else
        {
            return chunk[i];
        }
    }

    return default(char);
}

Stack<char> GetIncompleteChunk(string chunk)
{
    var chars = new Stack<char>();

    for (int i = 0; i < chunk.Length; i++)
    {
        if (chunkCharDictionary.ContainsKey(chunk[i]))
        {
            chars.Push(chunk[i]);
            continue;
        }

        var topChar = chars.Peek();

        if (chunkCharDictionary[topChar] == chunk[i])
        {
            chars.Pop();
        }
        else
        {
            return new Stack<char>();
        }
    }

    return chars;
}

BuildChunkCharDictionary();
BuildCharScoreDictionarty();
//SolvePartOne();
SolvePartTwo();