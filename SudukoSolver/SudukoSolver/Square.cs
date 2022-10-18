using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Square
    {
        private List<int> _square;
        public List<int> square { get { return _square; } set { _square = value; } }

        private int _postion;
        public int position => _postion;

        private bool _solved;
        public bool solved => _solved;

        private List<int> _tried;
        public List<int> tried => _tried;

        private int _unsolved;
        public int unsolved => _unsolved;

        public Square(List<int> square, int postion, bool solved, List<int> tried, int unsolved)
        {
            _square = square;
            _postion = postion;
            _solved = solved;
            _tried = tried;
            _unsolved = unsolved;
        }
    }
}
