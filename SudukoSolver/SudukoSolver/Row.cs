using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    public class Row
    {
        public List<int> row;
        public int rowNumber;
        public bool solved;
        public List<int> tried;
        public int unsolved;


        //Set up constructor for the class
        public Row(List<int> row, int rowNumber, bool solved, List<int> tried, int unsolved)
        {
            this.row = row;
            this.rowNumber = rowNumber;
            this.solved = solved;
            this.tried = tried;
            this.unsolved = unsolved;
        }


        //Returns the row with the most solved entities
        public static Row GetMostSolved(List<Row> myObjectList)
        {
            Row mostSolved = new Row(myObjectList[0].row, 0, false, myObjectList[0].tried, 9);

            foreach (Row row in myObjectList)
            {
                if (row.unsolved == 0)
                {
                    continue;
                }
                else if (row.unsolved < mostSolved.unsolved)
                {
                    mostSolved = row;
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
