using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Column
    {
        public List<int> column;
        public int columnNumber;
        public bool solved;
        public List<int> tried;
        public int unsolved;

        public Column (List<int> column, int columnNumber, bool solved, List<int> tried, int unsolved)
        {
            this.column = column;
            this.columnNumber = columnNumber;
            this.solved = solved;
            this.tried = tried;
            this.unsolved = unsolved;
        }
    }
}
