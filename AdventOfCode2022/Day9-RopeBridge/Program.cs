using Day9_RopeBridge;

var movementData = File.ReadAllLines("input.txt");

var positionVisited = new HashSet<Position>();

void MoveHeadAndTailForNKnots(int knots)
{
    var movementDictionary = BuildDirectionTuple();

    var startingPosition = new Position(0, 0);

    var knotList = GetKnotListForNKnots(knots, startingPosition);

    foreach (var movement in movementData)
    {
        var moveData = movement.Split(" ");

        var direction = moveData[0];
        var distance = int.Parse(moveData[1]);

        switch(direction)
        {
            case "R":
                MoveKnots(knotList, distance, movementDictionary[direction]);
                break;
            case "L":
                MoveKnots(knotList, distance, movementDictionary[direction]);
                break;
            case "U":
                MoveKnots(knotList, distance, movementDictionary[direction]);
                break;
            case "D":
                MoveKnots(knotList, distance, movementDictionary[direction]);
                break;
            default:
                throw new ArgumentException("Not a valid movement");
                break;
        }
    }
}

List<Position> GetKnotListForNKnots(int knots, Position startingPosition)
{
    var knotList = new List<Position>();

    for(int i = 0; i < knots; i++)
    {
        knotList.Add(new Position(startingPosition.row, startingPosition.col));
    }

    return knotList;
}

void MoveKnots(List<Position> ropeKnots, int distance, (int, int) direction)
{
    var maxDistance = Math.Sqrt(2);


    for(int d = 0; d < distance; d++)
    {
        ropeKnots[0].row += direction.Item1;
        ropeKnots[0].col += direction.Item2;
        
        for (int i = 1; i < ropeKnots.Count; i++)
        {
            var subtractionOfCol = ropeKnots[i - 1].col - ropeKnots[i].col;
            var subtractionOfRow = ropeKnots[i - 1].row - ropeKnots[i].row;

            var tailDistanceFromHead = Math.Sqrt(Math.Pow(subtractionOfCol, 2) + Math.Pow(subtractionOfRow, 2));

            if (tailDistanceFromHead > maxDistance)
            {
                if (Math.Abs(subtractionOfCol) > Math.Abs(subtractionOfRow))
                {
                    ropeKnots[i].row += subtractionOfRow;
                    ropeKnots[i].col += subtractionOfCol < 0 ? subtractionOfCol + 1 : subtractionOfCol - 1;
                }
                else if(Math.Abs(subtractionOfCol) < Math.Abs(subtractionOfRow))
                {
                    ropeKnots[i].row += subtractionOfRow < 0 ? subtractionOfRow + 1 : subtractionOfRow - 1;
                    ropeKnots[i].col += subtractionOfCol;
                }
                else
                {
                    ropeKnots[i].row += subtractionOfRow < 0 ? subtractionOfRow + 1 : subtractionOfRow - 1;
                    ropeKnots[i].col += subtractionOfCol < 0 ? subtractionOfCol + 1 : subtractionOfCol - 1;
                }
            }

            if (i == ropeKnots.Count - 1)
            {
                AddPositionToVisited(ropeKnots[ropeKnots.Count - 1].row, ropeKnots[ropeKnots.Count - 1].col);
            }
        }
    }
}

void AddPositionToVisited(int row, int col)
{
    var newPosition = new Position(row, col);

    if (!positionVisited.Contains(newPosition))
    {
        positionVisited.Add(newPosition);
    }
}


Dictionary<string, (int, int)> BuildDirectionTuple()
{
    var movementDictionary = new Dictionary<string, (int, int)>();

    movementDictionary.Add("U", (-1, 0));
    movementDictionary.Add("D", (1, 0));
    movementDictionary.Add("R", (0, 1));
    movementDictionary.Add("L", (0, -1));

    return movementDictionary;
}


BuildDirectionTuple();
MoveHeadAndTailForNKnots(2);
Console.WriteLine(positionVisited.Count);