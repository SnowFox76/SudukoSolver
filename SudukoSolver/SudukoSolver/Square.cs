using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Square
    {
        public List<int> square;
        public int position;
        public bool solved = false;
        public List<int> tried;

        public Square(List<int> square, int position, bool solved, List<int> tried)
        {
            this.square = square;
            this.position = position;
            this.solved = solved;
            this.tried = tried;
        }
    }
}
