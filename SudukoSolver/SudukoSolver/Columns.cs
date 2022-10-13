using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Columns
    {
        private List<int> column;
        private int columnNumber;
        private bool solved;
        private List<int> tried;

        public Columns (List<int> column, int columnNumber, bool solved, List<int> tried)
        {
            this.column = column;
            this.columnNumber = columnNumber;
            this.solved = solved;
            this.tried = tried;
        }
    }
}
