using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_GiantSquid
{
    public class GiantSquidBingo
    {

        private List<Board> boards;

        private int numberOfBoardsWon;

        public GiantSquidBingo()
        {
            boards = new List<Board>();
            numberOfBoardsWon = 0;
        }

        public void BuildBoards(string[] bingoData)
        {
            for (int i = 1; i < bingoData.Length; i++)
            {
                List<List<string>> board = new List<List<string>>();

                string[] rows = bingoData[i].Split("\r\n");

                foreach (string line in rows)
                {
                    List<string> row = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    board.Add(row);
                }

                Board b = new Board();
                b.rows = board;

                boards.Add(b);
            }
        }

        public int GetNumberOfBoards()
        {
            return boards.Count;
        }

        public void RunGame(string[] bingoNumbers, int stopAtNthWin = 1)
        {
            for(int i = 0; i < bingoNumbers.Length; i++)
            {
                Tuple<int, int> result =  CheckAndGetUnmarkedSumAndLastNumberCalledAfterFirstWin(bingoNumbers[i], stopAtNthWin);

                if(result.Item1 != -1 && result.Item2 != -1)
                {
                    PrintResultForFirstWin(result.Item1, result.Item2);
                    break;
                }
            }
        }

        private void PrintResultForWin(int sum, int lastCalled)
        {
            int result = sum * lastCalled;

            Console.WriteLine(result);
        }

        private Tuple<int, int> CheckAndGetUnmarkedSumAndLastNumberCalledAfterFirstWin(string bingoNumber, int numberToStopAt)
        {
            foreach (Board board in boards)
            {
                if (board.boardWon)
                {
                    continue;
                }
                board.CheckAndMarkValue(bingoNumber);

                var rowColList = board.GetUnmarkedWhenRowOrColWins();
                var diagonalList = board.GetUnmarkedWhenDiagonalWins();

                var unmarkedList = rowColList.Count > 0 ? rowColList : diagonalList;

                if (unmarkedList.Count > 0)
                {
                    numberOfBoardsWon++;
                    board.boardWon = true;

                    if (numberOfBoardsWon == numberToStopAt)
                    {
                        int sum = unmarkedList.Sum();
                        int lastCalled = Convert.ToInt32(bingoNumber);

                        return Tuple.Create(sum, lastCalled);
                    }
                }
            }

            return Tuple.Create(-1, -1);

        }
    }
}
