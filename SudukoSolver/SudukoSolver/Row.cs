using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Row
    {
        public List<int> row;
        public int rowNumber;
        public bool solved;
        public List<int> tried;
        public int unsolved;

        public Row(List<int> row, int rowNumber, bool solved, List<int> tried, int unsolved)
        {
            this.row = row;
            this.rowNumber = rowNumber;
            this.solved = solved;
            this.tried = tried;
            this.unsolved = unsolved;
        }
    }
}
