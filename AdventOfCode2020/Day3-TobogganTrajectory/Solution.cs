
var map = File.ReadAllLines("input.txt");


int depth = map.Length;


int GetNumberOfTreesAlongSlope(int horizontalMovement, int verticalMovement)
{
    int numberOfTrees = 0;

    int currentHorizontalPos = 0;
    int currentVerticalPos = 0;

    while (currentVerticalPos < depth)
    {
        if (map.ElementAt(currentVerticalPos).ElementAt(currentHorizontalPos) == '#')
        {
            numberOfTrees++;
        }

        currentHorizontalPos += horizontalMovement;

        currentHorizontalPos = currentHorizontalPos % map.ElementAt(0).Length;

        currentVerticalPos += verticalMovement;
    }

    return numberOfTrees;
}

int oneToOne = GetNumberOfTreesAlongSlope(1, 1);
int threeToOne = GetNumberOfTreesAlongSlope(3, 1);
int fiveToOne = GetNumberOfTreesAlongSlope(5, 1);
int sevenToOne = GetNumberOfTreesAlongSlope(7, 1);
int oneTotwo = GetNumberOfTreesAlongSlope(1, 2);


long result = oneToOne * threeToOne * fiveToOne * sevenToOne * oneTotwo;

Console.WriteLine(result);