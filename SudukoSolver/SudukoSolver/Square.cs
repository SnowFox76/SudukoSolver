using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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


        //Compute the indx of the square based on the colum and row reference.
        public static int GetSquareIndex(List<bool> openRow, List<bool> openCol)
        {
            try 
            {
                if (openRow.IndexOf(true) == 0)
                {
                    if (openCol.IndexOf(true) == 0)
                    {
                        return 0;
                    }
                    else if (openCol.IndexOf(true) == 1)
                    {
                        return 1;
                    }
                    else if (openCol.IndexOf(true) == 2)
                    {
                        return 2;
                    }
                }
                else if (openRow.IndexOf(true) == 1)
                {

                    if (openCol.IndexOf(true) == 0)
                    {
                        return 3;
                    }
                    else if (openCol.IndexOf(true) == 1)
                    {
                        return 4;
                    }
                    else if (openCol.IndexOf(true) == 2)
                    {
                        return 5;
                    }
                }
                else if (openRow.IndexOf(true) == 2)
                {

                    if (openCol.IndexOf(true) == 0)
                    {
                        return 6;
                    }
                    else if (openCol.IndexOf(true) == 1)
                    {
                        return 7;
                    }
                    else if (openCol.IndexOf(true) == 2)
                    {
                        return 8;
                    }
                }

                return 9;

            } catch (IndexOutOfRangeException)
            {
                return 9;
            }
            

                              
        }


        //Return a valid candidate for ckecking against the rows and columns
        public static int GetValidCandidate(List<int> square)
        {
            int candidateValue;
            do
            {
                candidateValue = GetRandomNumber();
            } while (square.Contains(candidateValue) = false);
        }


        //Inserts one candidate into a square
        public static (Square square, int updatedSquareIndex ,int candidateValue, int candidateIndex) NewCandidateToSquare(Dictionary<Square, List<Row>> rowReference, Dictionary<Square, List<Column>> colReference, List<Square> sudokuSqrs)
        {
            bool validCandidate = false;
            int candidateIndex = 0;            
            int candidateValue = 0;
            int triedCount = 0;

            Square mostSolvedSquare = GetMostSolved(sudokuSqrs);
            int updatedSquareIndex = sudokuSqrs.IndexOf(mostSolvedSquare);

            do
            {
                candidateValue = GetRandomNumber();

                (candidateIndex, validCandidate) = CheckCandidate(candidateValue, rowReference[mostSolvedSquare], colReference[mostSolvedSquare]);

                if (validCandidate)
                {
                    break;
                }

                triedCount++;

            } while (triedCount < 11); 

            if (validCandidate)
            {
                List<int> tempSquareList = mostSolvedSquare.square;
                tempSquareList[candidateIndex] = candidateValue;
                mostSolvedSquare.square = tempSquareList;

                return (mostSolvedSquare, updatedSquareIndex, candidateValue, candidateIndex);
            }
            else
            {
                (Square square, candidateValue, candidateIndex) = CandidateToSquare(mostSolvedSquare);

                return (square, updatedSquareIndex, candidateValue, candidateIndex);
            }            
        }


        //?Recursively? check the candidate for for clashed in rows and or columns
        static (int candidateIndex, bool validCandidate) CheckCandidate(int candidate, List<Row> Rows, List<Column> Columns)
        {            
            List<bool> openRow = new List<bool>();
            List<bool> openCol = new List<bool>();

            foreach (Row row in Rows)
            {
                bool validOption = row.row.Contains(candidate) ^ row.row.Contains(0) ? true : false;
                if (validOption)
                {
                    bool optionCheck = row.row.Contains(candidate) ? false : true;
                    openRow.Add(optionCheck);
                }
                else
                {
                    openRow.Add(validOption);
                }                                     
            }
            
            foreach (Column column in Columns)
            {
                bool validOption = column.column.Contains(candidate) ^ column.column.Contains(0) ? true : false;
                if (validOption)
                {
                    bool optionCheck = column.column.Contains(candidate) ? false : true;
                    openCol.Add(optionCheck);
                }
                else
                {
                    openCol.Add(validOption);
                }
            }

            //Return values based on the boolean values found in the lists
            if (openRow.Contains(true) && openCol.Contains(true))
            {   
                bool validCandidate = true;
                int candidateIndex = GetSquareIndex(openRow, openCol);
                return (candidateIndex , validCandidate);
            }
            else
            {
                bool validCandidate = false;
                int candidateIndex = 0;
                return (candidateIndex, validCandidate);
            }
        }

        
        //Inserts the candidate into the sqaure object
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
                    (List<int> tempSquareList, candidateIndex) = SudokuSolver.InsertCadidate(Square.square, candidateValue);
                    Square.square = tempSquareList;
                    newCandidate = true;
                }
            }
            return (Square, candidateValue, candidateIndex);
        }
    }
}