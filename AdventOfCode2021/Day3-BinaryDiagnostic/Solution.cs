
using System.Text;

var diagnosticData = File.ReadAllLines("input.txt");

// Solution for the first part
StringBuilder gammaRateBuilder = new StringBuilder();
StringBuilder epsilonRateBuilder = new StringBuilder();

for (int i = 0; i < diagnosticData.ElementAt(0).Length; i++)
{
    int[] mostBitArr = new int[2];

    int [] leastBitArr = new int[2];

    foreach (var data in diagnosticData)
    {
        int num = Int16.Parse($"{data.ElementAt(i)}");

        mostBitArr[num]++;
        leastBitArr[num]++;
    }

    int maxCommonBit = mostBitArr[0] > mostBitArr[1] ? 0 : 1;
    int leastCommonBit = leastBitArr[0] < mostBitArr[1] ? 0 : 1;

    gammaRateBuilder.Append(maxCommonBit);
    epsilonRateBuilder.Append(leastCommonBit);
}

int gammaRate = Convert.ToInt32(gammaRateBuilder.ToString(), 2);
int epsilonRate = Convert.ToInt32(epsilonRateBuilder.ToString(), 2);

long result = gammaRate * epsilonRate;

Console.WriteLine(result);


// Solution for the second part

string GetOxygenGeneratorRating(List<string> dData)
{
    List<string> oxygenGeneratorRatingList = new List<string>(dData);
    
    for(int i = 0; i < dData.First().Length; i++)
    {
        List<string> oneBitList = new List<string>();
        List<string> zeroBitList = new List<string>();

        foreach (var rating in oxygenGeneratorRatingList)
        {
            if(rating.ElementAt(i) == '0')
            {
                zeroBitList.Add(rating);
            }
            else
            {
                oneBitList.Add(rating);
            }
        }

        oxygenGeneratorRatingList = zeroBitList.Count > oneBitList.Count ? zeroBitList : oneBitList;

        if(oxygenGeneratorRatingList.Count == 1)
        {
            break;
        }
    }

    return oxygenGeneratorRatingList.First();
}

string GetCo2ScrubberRating(List<string> dData)
{
    List<string> co2ScrubberRatingList = new List<string>(dData);

    for (int i = 0; i < dData.First().Length; i++)
    {
        List<string> oneBitList = new List<string>();
        List<string> zeroBitList = new List<string>();

        foreach (var rating in co2ScrubberRatingList)
        {
            if (rating.ElementAt(i) == '0')
            {
                zeroBitList.Add(rating);
            }
            else
            {
                oneBitList.Add(rating);
            }
        }

        co2ScrubberRatingList = zeroBitList.Count <= oneBitList.Count ? zeroBitList : oneBitList;

        if (co2ScrubberRatingList.Count == 1)
        {
            break;
        }
    }

    return co2ScrubberRatingList.First();
}

int oxygenGeneratorRating = Convert.ToInt32(GetOxygenGeneratorRating(diagnosticData.ToList()), 2);
int co2ScrubberRating = Convert.ToInt32(GetCo2ScrubberRating(diagnosticData.ToList()), 2);

result = oxygenGeneratorRating * co2ScrubberRating;

Console.WriteLine(result);

