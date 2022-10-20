using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    public class Square
    {
        private List<int> _square;
        private int _postion;
        private bool _solved;
        private List<int> _tried;
        private int _unsolved;
        

        //Set constructor for the class
        public Square(List<int> square, int postion, bool solved, List<int> tried, int unsolved)
        {
            _square = square;
            _postion = postion;
            _solved = solved;
            _tried = tried;
            _unsolved = unsolved;
        }


        //Get and set methods for the properties of the class
        public int unsolved
        {
            get { return _unsolved; }
            set { _unsolved = value; }
        }
        public List<int> tried
        {
            get { return _tried; }
            set { _tried = value; }
        }
        public bool solved
        {
            get { return _solved; }
            set { _solved = value; }
        }
        public int position
        {
            get { return _postion; }
            set { _postion = value; }
        }
        public List<int> square
        {
            get { return _square; }
            set { _square = value; }
        }


        //Converts the user input to a the square of values
        public static List<int> GetSquare(List<List<int>> sudokuPuzzle, int position)
        {
            var temp_square = new List<int>();

            foreach (List<int> row in sudokuPuzzle)
            {
                if (sudokuPuzzle.IndexOf(row) == 0 || sudokuPuzzle.IndexOf(row) == 1 || sudokuPuzzle.IndexOf(row) == 2)
                {
                    if (position % 3 == 0)
                    {
                        //temp_square.Add(row[:3]);
                        for (int i = 0; i < 3; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else if (position % 3 == 1)
                    {
                        //temp_square.Add(row[3:6]);
                        for (int i = 3; i < 6; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        //temp_square.Add(row[6:9]);
                        for (int i = 6; i < 9; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                }
                else if (sudokuPuzzle.IndexOf(row) == 3 || sudokuPuzzle.IndexOf(row) == 4 || sudokuPuzzle.IndexOf(row) == 5)
                {
                    if (position % 3 == 0)
                    {
                        //temp_square.Add(row[:3]);
                        for (int i = 0; i < 3; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else if (position % 3 == 1)
                    {
                        //temp_square.Add(row[3:6]);
                        for (int i = 3; i < 6; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        //temp_square.Add(row[6:9]);
                        for (int i = 6; i < 9; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                }
                else
                {
                    if (position % 3 == 0)
                    {
                        //temp_square.Add(row[:3]);
                        for (int i = 0; i < 3; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else if (position % 3 == 1)
                    {
                        //temp_square.Add(row[3:6]);
                        for (int i = 3; i < 6; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        //temp_square.Add(row[6:9]);
                        for (int i = 6; i < 9; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                }
            }

            //Remove the excess squares added to the list
            if (position < 3)
            {
                temp_square.RemoveRange(9, 18);
            }
            else if (position > 2 && position < 6)
            {
                temp_square.RemoveRange(0, 9);
                temp_square.RemoveRange(9, 9);
            }
            else
            {
                temp_square.RemoveRange(0, 18);
            }

            return temp_square;
        }


        //Returns the square with the most solved entities
        public static Square GetMostSolved(List<Square> myObjectList)
        {
            Square mostSolved = myObjectList[0];

            foreach (Square sqr in myObjectList)
            {
                if (sqr.unsolved == 0)
                {
                    continue;
                }
                else if (mostSolved.unsolved == 0)
                {
                    mostSolved = sqr;
                }
                else if (sqr.unsolved < mostSolved.unsolved)
                {
                    mostSolved = sqr;
                }
                else
                {
                    continue;
                }
            }

            return mostSolved;
        }


        //Calls a random integer
        private static int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 10);
        }



        //Inserts one candidate into a square
        public static (Square square, int candidateValue, int candidateIndex) CandidateToSquare(Square Square)
        {
            bool newCandidate = false;
            int candidateValue = 0;
            int candidateIndex = 0;

            while (newCandidate == false)
            {
                candidateValue = GetRandomNumber();

                if (Square.square.Contains(candidateValue) == true)
                {
                    continue;
                }
                else
                {
                    (List<int> tempSquareList, candidateIndex) = Testing.InsertCadidate(Square.square, candidateValue);
                    Square.square = tempSquareList;
                    newCandidate = true;
                }
            }
            return (Square, candidateValue, candidateIndex);
        }
    }
}
