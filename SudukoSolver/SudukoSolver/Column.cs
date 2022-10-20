using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    public class Column
    {
        public List<int> column;
        public int columnNumber;
        public bool solved;
        public List<int> tried;
        public int unsolved;


        //Set up the constructor the class
        public Column (List<int> column, int columnNumber, bool solved, List<int> tried, int unsolved)
        {
            this.column = column;
            this.columnNumber = columnNumber;
            this.solved = solved;
            this.tried = tried;
            this.unsolved = unsolved;
        }


        //Generates the column 
        public static List<int> GetColumn(List<List<int>> sudokuPuzzle, int columnNumber)
        {
            var temp_column = new List<int>();
            foreach (List<int> row in sudokuPuzzle)
            {
                temp_column.Add(row[columnNumber]);
            }

            return temp_column;
        }

        public static Column GetMostSolved(List<Column> myObjectList)
        {
            Column mostSolved = new Column(myObjectList[0].column, 0, false, myObjectList[0].tried, 9);

            foreach (Column col in myObjectList)
            {
                if (col.unsolved == 0)
                {
                    continue;
                }
                else if (col.unsolved < mostSolved.unsolved)
                {
                    mostSolved = col;
                }
                else
                {
                    continue;
                }
            }

            return mostSolved;
        }
    }
}
