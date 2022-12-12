using Day9_RopeBridge;

var movementData = File.ReadAllLines("input.txt");

var grid = new int[100, 100];

var positionVisited = new HashSet<Position>();

void MoveHeadAndTail()
{
    var startingPosition = new Position(grid.GetLength(0) - 1, 0);

    grid[startingPosition.row, startingPosition.col] = 1;

    var currentHeadPosition = new Position(startingPosition.row, startingPosition.col);
    var currentTailPosition = new Position(startingPosition.row, startingPosition.col);

    foreach (var movement in movementData)
    {
        var moveData = movement.Split(" ");

        var direction = moveData[0];
        var distance = int.Parse(moveData[1]);

        switch(direction)
        {
            case "R":
                MoveRight(currentHeadPosition, currentTailPosition, distance);
                break;
            case "L":
                MoveLeft(currentHeadPosition, currentTailPosition, distance);
                break;
            case "U":
                MoveUp(currentHeadPosition, currentTailPosition, distance);
                break;
            case "D":
                MoveDown(currentHeadPosition, currentTailPosition, distance);
                break;
            default:
                throw new ArgumentException("Not a valid movement");
                break;
        }
    }
}

void MoveRight(Position headPosition, Position tailPosition, int distance)
{
    var maxDistance = Math.Sqrt(2);

    for(int i = 1;i <= distance; i++)
    {
        headPosition.col += 1;

        var subtractionOfX = headPosition.col - tailPosition.col;
        var subtractionOfY = headPosition.row - tailPosition.row;

        var tailDistanceFromHead = Math.Sqrt(Math.Pow(subtractionOfX, 2) + Math.Pow(subtractionOfY, 2));

        if (tailDistanceFromHead > maxDistance)
        {
            tailPosition.row = headPosition.row;
            tailPosition.col = headPosition.col - 1;
        }

        AddPositionToVisited(tailPosition.row, tailPosition.col);
    }
}


void MoveLeft(Position headPosition, Position tailPosition, int distance)
{
    var maxDistance = Math.Sqrt(2);

    for (int i = 1; i <= distance; i++)
    {
        headPosition.col -= 1;

        var subtractionOfX = headPosition.col - tailPosition.col;
        var subtractionOfY = headPosition.row - tailPosition.row;

        var tailDistanceFromHead = Math.Sqrt(Math.Pow(subtractionOfX, 2) + Math.Pow(subtractionOfY, 2));

        if (tailDistanceFromHead > maxDistance)
        {
            tailPosition.row = headPosition.row;
            tailPosition.col = headPosition.col + 1;
        }

        AddPositionToVisited(tailPosition.row, tailPosition.col);
    }
}

void MoveUp(Position headPosition, Position tailPosition, int distance)
{
    var maxDistance = Math.Sqrt(2);

    for (int i = 1; i <= distance; i++)
    {
        headPosition.row -= 1;

        var subtractionOfX = headPosition.col - tailPosition.col;
        var subtractionOfY = headPosition.row - tailPosition.row;

        var tailDistanceFromHead = Math.Sqrt(Math.Pow(subtractionOfX, 2) + Math.Pow(subtractionOfY, 2));

        if (tailDistanceFromHead > maxDistance)
        {
            tailPosition.col = headPosition.col;
            tailPosition.row = headPosition.row + 1;
        }

        AddPositionToVisited(tailPosition.row, tailPosition.col);
    }
}

void MoveDown(Position headPosition, Position tailPosition, int distance)
{
    var maxDistance = Math.Sqrt(2);

    for (int i = 1; i <= distance; i++)
    {
        headPosition.row += 1;

        var subtractionOfX = headPosition.col - tailPosition.col;
        var subtractionOfY = headPosition.row - tailPosition.row;

        var tailDistanceFromHead = Math.Sqrt(Math.Pow(subtractionOfX, 2) + Math.Pow(subtractionOfY, 2));

        if (tailDistanceFromHead > maxDistance)
        {
            tailPosition.col = headPosition.col;
            tailPosition.row = headPosition.row - 1;
        }

        AddPositionToVisited(tailPosition.row, tailPosition.col);
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


MoveHeadAndTail();
Console.WriteLine(positionVisited.Count);