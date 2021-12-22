using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_SevenSegmentSearch.SevenSegmentModels
{
    public class SevenSegmentDisplay
    {
        public Dictionary<int, string> numberToSegmentDisplayDictionary;

        public Dictionary<string, int> segmentToNumberDictionary;

        public SevenSegmentDisplay()
        {
            numberToSegmentDisplayDictionary = new Dictionary<int, string>();
            segmentToNumberDictionary = new Dictionary<string, int>();
        }

        public void MapAllSegmentToNumbers(string[] numberSegments)
        {
            var uniqueLengths = new Dictionary<int, int>() 
            {
                { 2, 1 },
                { 3, 7 },
                { 4, 4 },
                { 7, 8 }
            };

            var uniqueValueDictionary = new Dictionary<int, string>();

            foreach(var numberSegment in numberSegments)
            {
                if(uniqueLengths.ContainsKey(numberSegment.Length))
                {
                    uniqueValueDictionary.Add(uniqueLengths[numberSegment.Length], numberSegment);

                    numberToSegmentDisplayDictionary.Add(uniqueLengths[numberSegment.Length], numberSegment);
                    var segment = String.Concat(numberSegment.OrderBy(x => x));
                    segmentToNumberDictionary.Add(segment, uniqueLengths[numberSegment.Length]);
                }
            }

            AddNumberNineToDictionary(numberSegments, uniqueValueDictionary);
            
            AddNumberThreeToDictionary(numberSegments);

            AddNumberSixToDictionary(numberSegments);

            AddNumberFiveToDictionary(numberSegments);

            AddNumberTwoToDictionary(numberSegments);

            AddNumberZeroToDictionary(numberSegments);
        }

        private void AddNumberNineToDictionary(string[] numberSegments, Dictionary<int, string> uniqueValueDictionary)
        {
            var numbersToUse = new int[] { 1, 4, 7 };

            var nineSegmentHashSet = new HashSet<char>();

            for(int i = 0;i < numbersToUse.Length; i++)
            {
                string value = uniqueValueDictionary[numbersToUse[i]];

                foreach(var character in value)
                {
                    nineSegmentHashSet.Add(character);
                }
            }

            foreach(var numberSegment in numberSegments)
            {
                var segmentHash = numberSegment.ToCharArray().ToHashSet();

                int count = segmentHash.Intersect(nineSegmentHashSet).ToList().Count;

                if (count == nineSegmentHashSet.Count && numberSegment.Length == 6)
                {
                    numberToSegmentDisplayDictionary.Add(9, numberSegment);
                    var segment = String.Concat(numberSegment.OrderBy(x => x));
                    segmentToNumberDictionary.Add(segment, 9);
                    break;
                }
            }
        }

        private void AddNumberThreeToDictionary(string[] numberSegments)
        {
            var numbersToUse = new int[] { 1, 7 };

            var threeSegmentHash = new HashSet<char>();

            foreach(var number in numbersToUse)
            {
                string segment = numberToSegmentDisplayDictionary[number];

                foreach(var character in segment)
                {
                    threeSegmentHash.Add(character);
                }
            }

            foreach(var numberSegment in numberSegments)
            {
                var segmentHash = numberSegment.ToCharArray().ToHashSet();

                int count = segmentHash.Intersect(threeSegmentHash).ToList().Count;

                if (segmentHash.Count == 5 && count == threeSegmentHash.Count)
                {
                    numberToSegmentDisplayDictionary.Add(3, numberSegment);
                    var segment = String.Concat(numberSegment.OrderBy(x => x));
                    segmentToNumberDictionary.Add(segment, 3);
                    break;
                }
            }
        }        

        private void AddNumberSixToDictionary(string[] numberSegments)
        {
            var numberOneHash = numberToSegmentDisplayDictionary[1].ToCharArray().ToHashSet();

            var numberEightHash = numberToSegmentDisplayDictionary[8].ToCharArray().ToHashSet();

            foreach(var numberSegment in numberSegments)
            {
                var segmentHash = numberSegment.ToCharArray().ToHashSet();

                if(numberSegment.Length == 6)
                {
                    int countOne = numberOneHash.Intersect(segmentHash).ToList().Count;
                    int countEight = numberEightHash.Intersect(segmentHash).ToList().Count;

                    if(countOne == 1 && countEight == 6)
                    {
                        numberToSegmentDisplayDictionary.Add(6, numberSegment);
                        var segment = String.Concat(numberSegment.OrderBy(x => x));
                        segmentToNumberDictionary.Add(segment, 6);
                        break;
                    }
                }
            }
        }

        private void AddNumberFiveToDictionary(string[] numberSegments)
        {
            var numberOneHash = numberToSegmentDisplayDictionary[1].ToCharArray().ToHashSet();

            var numberSixHash = numberToSegmentDisplayDictionary[6].ToCharArray().ToHashSet();

            foreach (var numberSegment in numberSegments)
            {
                var segmentHash = numberSegment.ToCharArray().ToHashSet();

                if (numberSegment.Length == 5)
                {
                    int countOne = numberOneHash.Intersect(segmentHash).ToList().Count;
                    int countSix = numberSixHash.Intersect(segmentHash).ToList().Count;

                    if (countOne == 1 && countSix == 5)
                    {
                        numberToSegmentDisplayDictionary.Add(5, numberSegment);
                        var segment = String.Concat(numberSegment.OrderBy(x => x));
                        segmentToNumberDictionary.Add(segment, 5);
                        break;
                    }
                }
            }
        }

        private void AddNumberTwoToDictionary(string[] numberSegments)
        {
            var numberOneHash = numberToSegmentDisplayDictionary[1].ToCharArray().ToHashSet();

            var numberFiveHash = numberToSegmentDisplayDictionary[5].ToCharArray().ToHashSet();

            foreach (var numberSegment in numberSegments)
            {
                var segmentHash = numberSegment.ToCharArray().ToHashSet();

                if (numberSegment.Length == 5)
                {
                    int countOne = numberOneHash.Intersect(segmentHash).ToList().Count;
                    int countFive = numberFiveHash.Intersect(segmentHash).ToList().Count;

                    if (countOne == 1 && countFive == 3)
                    {
                        numberToSegmentDisplayDictionary.Add(2, numberSegment);
                        var segment = String.Concat(numberSegment.OrderBy(x => x));
                        segmentToNumberDictionary.Add(segment, 2);
                        break;
                    }
                }
            }
        }

        private void AddNumberZeroToDictionary(string[] numberSegments)
        {
            foreach(var numberSegment in numberSegments)
            {
                var segment = String.Concat(numberSegment.OrderBy(x => x));
                if (!segmentToNumberDictionary.ContainsKey(segment))
                {
                    numberToSegmentDisplayDictionary.Add(0, segment);
                    segmentToNumberDictionary.Add(segment, 0);
                    break;
                }
            }
        }
    }
}
