using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Rows
    {
        private List<int> row;
        private int rowNumber;
        private bool solved;
        private List<int> tried;

        public Rows(List<int> row, int rowNumber, bool solved, List<int> tried)
        {
            this.row = row;
            this.rowNumber = rowNumber;
            this.solved = solved;
            this.tried = tried;
        }
    }
}
