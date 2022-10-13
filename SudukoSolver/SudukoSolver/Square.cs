using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Square
    {
        private List<int> square;
        private int position;
        private bool solved = false;
        private List<int> tried;

        public Square(List<int> square, int position, bool solved, List<int> tried)
        {
            this.square = square;
            this.position = position;
            this.solved = solved;
            this.tried = tried;
        }
    }
}
