
using Day9_SmokeBasin;

var heightMapData = File.ReadAllLines("input.txt");

var directions = new int[4,2]
{
    { 0, -1 }, // North
    { 1, 0 }, // East
    { 0, 1 }, // South
    { -1, 0 }  // West
};


List<List<int>> heightMapList = new List<List<int>>();
Dictionary<Tuple<int, int>, int> lowPointIndexDictionary = new Dictionary<Tuple<int, int>,int>();

foreach(var row in heightMapData)
{
    var rowList = row.Select(x => Convert.ToInt32(x + "")).ToList();

    heightMapList.Add(rowList);
}

List<int> GetAllLowPoints()
{
    List<int> lowPoints = new List<int>();

    for(int i = 0;i < heightMapList.Count;i++)
    {
        for(int j = 0;j < heightMapList[i].Count;j++)
        {
            if (isPointALowPoint(i, j, heightMapList, heightMapList[i][j]))
            {
                lowPoints.Add(heightMapList[i][j]);

                lowPointIndexDictionary.Add(Tuple.Create(i, j), heightMapList[i][j]);
            }
        }
    }

    return lowPoints;
}

bool isPointALowPoint(int row, int col, List<List<int>> heightMapList, int value)
{
    int neighbors = 4;

    int count = 0;
    int len = directions.GetLength(0);
    for(int i = 0;i < len;i++)
    {
        int r = row + directions[i, 1];

        int c = col + directions[i, 0];

        if(r < 0 || r > heightMapList.Count - 1 ||
            c < 0 || c >  heightMapList[0].Count - 1)
        {
            neighbors--;
            continue;
        }

        if(heightMapList[r][c] <= value)
        {
            break;
        }

        count++;
    }

    return count == neighbors;
}

var allLowPoints = GetAllLowPoints();
int sum = allLowPoints.Sum() + allLowPoints.Count;

Console.WriteLine(sum);


// Solution to part two
List<int> basinSizes = new List<int>();
foreach (var item in lowPointIndexDictionary)
{
    int pointValue = item.Value;
    int row = item.Key.Item1;
    int col = item.Key.Item2;

    int size = GetSizeofBasinWithLowPoint(item.Value, row, col);    

    basinSizes.Add(size);
}


int GetSizeofBasinWithLowPoint(int point, int row, int col)
{

    Queue<BasinPoint> queue = new Queue<BasinPoint>();

    queue.Enqueue(new BasinPoint(row, col, point));

    int count = 0;
    HashSet<BasinPoint> visited = new HashSet<BasinPoint>();

    while (queue.Count > 0)
    {
        int size = queue.Count;

        while(size > 0)
        {
            BasinPoint basinPoint = queue.Dequeue();

            List<BasinPoint> basinPoints = GetAllNeighbors(basinPoint.row, basinPoint.col, basinPoint.pointValue, visited);
            count++;
            foreach(BasinPoint bp in basinPoints)
            {
                queue.Enqueue(bp);
            }

            size--;
        }
    }

    return count;
}

List<BasinPoint> GetAllNeighbors(int row, int col, int point, HashSet<BasinPoint> visited)
{
    List<BasinPoint> list = new List<BasinPoint>();

    for(int i = 0;i < directions.GetLength(0); i++)
    {
        int r = row + directions[i, 1];
        int c = col + directions[i, 0];

        if (r < 0 || r > heightMapList.Count - 1 ||
            c < 0 || c > heightMapList[0].Count - 1)
        {
            continue;
        }

        if (heightMapList[r][c] != 9 && heightMapList[r][c] > point)
        {
            BasinPoint bp = new BasinPoint(r, c, heightMapList[r][c]);

            if (!visited.Contains(bp))
            {
                visited.Add(bp);
                list.Add(bp);
            }
        }
    }

    return list;
}



basinSizes.Sort();

long answer = 1;
int last = basinSizes.Count - 1;

for (int i = last; i > last - 3; i--)
{
    answer *= basinSizes[i];
}

Console.WriteLine(answer);