var signal = File.ReadAllText("input.txt");

int GetMarkerCharIndexAfterNthindex(int n)
{
    int markerIndex = -1;
    var markerDictionary = new Dictionary<char, int>();

    int index = 0;
    foreach (var character in signal)
    {

        if(markerDictionary.ContainsKey(character))
        {
            int charIndex = markerDictionary[character];

            var markerDictionaryKeys = markerDictionary.Keys;

            foreach(var key in markerDictionaryKeys)
            {
                if (markerDictionary[key] <= charIndex)
                {
                    markerDictionary.Remove(key);
                }
            }
        }

        markerDictionary.Add(character, index);

        if (markerDictionary.Count == n)
        {
            markerIndex = index + 1;
            break;
        }

        index++;
    }

    return markerIndex;
}

Console.WriteLine(GetMarkerCharIndexAfterNthindex(4));
Console.WriteLine(GetMarkerCharIndexAfterNthindex(14));