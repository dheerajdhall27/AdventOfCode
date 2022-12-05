using System.Collections.Generic;
using System.Text;

namespace Day10_SyntaxScoring;

internal class SyntaxScorer
{
    private Dictionary<char, char> _charMapperDictionary;

    private Dictionary<char, int> _invalidCharacterScoreDictionary;

    private Dictionary<char, int> _incompleteCharacterScoreDictionary;

    public SyntaxScorer()
    {
        _charMapperDictionary = new Dictionary<char, char>();
        _invalidCharacterScoreDictionary = new Dictionary<char, int>();
        _incompleteCharacterScoreDictionary = new Dictionary<char, int>();

        MapChunkChar();
        BuildCharScoreDictionary();
    }

    void MapChunkChar()
    {
        _charMapperDictionary.Add('(', ')');
        _charMapperDictionary.Add('[', ']');
        _charMapperDictionary.Add('{', '}');
        _charMapperDictionary.Add('<', '>');
    }

    void BuildCharScoreDictionary()
    {
        _invalidCharacterScoreDictionary.Add(')', 3);
        _invalidCharacterScoreDictionary.Add(']', 57);
        _invalidCharacterScoreDictionary.Add('}', 1197);
        _invalidCharacterScoreDictionary.Add('>', 25137);

        _incompleteCharacterScoreDictionary.Add(')', 1);
        _incompleteCharacterScoreDictionary.Add(']', 2);
        _incompleteCharacterScoreDictionary.Add('}', 3);
        _incompleteCharacterScoreDictionary.Add('>', 4);
    }

    public int GetScoreForInvalidChunks(List<string> chunks)
    {
        int score = 0;
        foreach (var chunk in chunks)
        {
            var invalidCharacter = GetInvalidCharacterIfAny(chunk);

            if (invalidCharacter != '\0')
            {
                score += _invalidCharacterScoreDictionary[invalidCharacter];
            }
        }

        return score;
    }

    public long GetScoreForIncompleteChunks(List<string> chunks)
    {
        var list = new List<long>();
        foreach (var chunk in chunks)
        {
            var incompleteStack = GetStackOfIncompleteChunk(chunk);

            if(incompleteStack.Count > 0)
            {
                var score = ProcessScoreForIncompleteChunk(incompleteStack);
                list.Add(score);
            }
        }

        list.Sort();

        return list[list.Count / 2];
    }

    private long ProcessScoreForIncompleteChunk(Stack<char> incompleteChunkStack)
    {
        var chunkBuilder = new StringBuilder();

        while (incompleteChunkStack.Count > 0)
        {
            var openingChar = incompleteChunkStack.Pop();
            chunkBuilder.Append(_charMapperDictionary[openingChar]);
        }

        var remainingChunk = chunkBuilder.ToString();

        long score = 0;

        foreach (char c in remainingChunk)
        {
            score = score * 5;
            score += _incompleteCharacterScoreDictionary[c];
        }

        return score;
    }

    private char GetInvalidCharacterIfAny(string chunk)
    {
        var chars = new Stack<char>();

        for (int i = 0; i < chunk.Length; i++)
        {
            if (_charMapperDictionary.ContainsKey(chunk[i]))
            {
                chars.Push(chunk[i]);
                continue;
            }

            var topChar = chars.Peek();

            if (_charMapperDictionary[topChar] == chunk[i])
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

    private Stack<char> GetStackOfIncompleteChunk(string chunk)
    {
        var chars = new Stack<char>();

        for (int i = 0; i < chunk.Length; i++)
        {
            if (_charMapperDictionary.ContainsKey(chunk[i]))
            {
                chars.Push(chunk[i]);
                continue;
            }

            var topChar = chars.Peek();

            if (_charMapperDictionary[topChar] == chunk[i])
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
}
