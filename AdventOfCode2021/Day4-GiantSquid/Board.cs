using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_GiantSquid
{
    public class Board
    {
        public List<List<string>> rows;

        public bool boardWon;

        public Board()
        {
            rows = new List<List<string>>();
            boardWon = false;
        }

        public void CheckAndMarkValue(string num)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Count; j++)
                {
                    if (rows[i][j] == num)
                    {
                        rows[i][j] += "M";
                        return;
                    }
                }
            }
        }

        public List<int> GetUnmarkedWhenDiagonalWins()
        {
            int leftCount = 0;
            int rightCount = 0;

            for (int i = 0, j = rows.Count - 1; i < rows.Count(); i++, j--)
            {
                if (rows[i][i].Contains("M"))
                {
                    leftCount++;
                }
                else if (rows[j][j].Contains("M"))
                {
                    rightCount++;
                }
            }

            if (leftCount == 5 || rightCount == 5)
            {
                return GetUnmarked();
            }

            return new List<int>();
        }

        public List<int> GetUnmarkedWhenRowOrColWins()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                int rowCount = 0;
                int colCount = 0;

                for (int j = 0; j < rows[i].Count; j++)
                {
                    if (rows[i][j].Contains("M"))
                    {
                        rowCount++;
                    }

                    if (rows[j][i].Contains("M"))
                    {
                        colCount++;
                    }
                }

                if (rowCount == 5 || colCount == 5)
                {
                    return GetUnmarked();
                }
            }

            return new List<int>();
        }

        private List<int> GetUnmarked()
        {
            List<int> unmarkedList = new List<int>();

            for (int i = 0; i < rows.Count(); i++)
            {
                for (int j = 0; j < rows[i].Count(); j++)
                {
                    if (!rows[i][j].Contains("M"))
                    {
                        unmarkedList.Add(Convert.ToInt32(rows[i][j]));
                    }
                }
            }

            return unmarkedList;
        }
    }
}
