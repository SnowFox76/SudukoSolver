using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    internal class Testing
    {
        //Displays out a list
        static void MyPrinter(List<int> array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            //Console.WriteLine("\n");
        }



        //Displays the entire Sudoku board
        static void MySudokuPrinter(List<List<int>> myPuzzleLists )
        {
            int loopCount = 0;
            foreach (var myList in myPuzzleLists)
            {
                Console.Write($"\n{loopCount}  :  ");
                MyPrinter(myList);
                loopCount++;
            }
        }



        //Find the slot where the candidate can be inserted, and inserts the candidate
        static List<int> InsertCadidate(List<int> array, int candidate)
        {
            int open_slot = array.IndexOf(0);
            array[open_slot] = candidate;

            return array;
        }



        //Completes one list
        static List<int> RowSolver(List<int> array)
        {
            var temp_array = new List<int> { };
            Random rnd = new Random();

            while (array.Contains(0) == true)
            {
                int candidate = rnd.Next(1, 10);
                if (array.Contains((int)candidate))
                {
                    continue;
                }
                else
                {
                    temp_array = InsertCadidate(array, candidate);
                    array = temp_array;
                }
            }
            return array;
        }



        //Get the number of unsolved numbers in a list
        static int GetNumberOfUnsolved(List<int> array)
        {
            int unsolved = 0;
            foreach (var item in array)
            {
                if (item == 0)
                {
                    unsolved++;
                }
                else
                {
                    continue;
                }
            }

            return unsolved;
        }

        

        //Choose the square with the least unsolved numbers
        static int ChooseSquare()
        {
            int test = 1;
            return test;
        }



        //Create the column
        static List<int> GetColumn(List<List<int>> sudokuPuzzle, int columnNumber)
        {
            var temp_column = new List<int>();
            foreach (List<int> row in sudokuPuzzle)
            {
                temp_column.Add(row[columnNumber]);
            }
            
            return temp_column;
        }



        //Create the square
        static List<int> GetSquare(List<List<int>> sudokuPuzzle, int position)
        {
            var temp_square = new List<int>();

            foreach (List<int> row in sudokuPuzzle)
            {
                if (position % 3 == 0)
                {
                    if (sudokuPuzzle.IndexOf(row) == 0 || sudokuPuzzle.IndexOf(row) == 1 || sudokuPuzzle.IndexOf(row) == 2)
                    {
                        //temp_square.Add(row[:3]);
                        for (int i = 0; i < 3; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (position % 3 == 1)
                {
                    if (sudokuPuzzle.IndexOf(row) == 3 || sudokuPuzzle.IndexOf(row) == 4 || sudokuPuzzle.IndexOf(row) == 5)
                    {
                        //temp_square.Add(row[3:6]);
                        for (int i = 3; i < 6; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (sudokuPuzzle.IndexOf(row) == 6 || sudokuPuzzle.IndexOf(row) == 7 || sudokuPuzzle.IndexOf(row) == 8)
                    {
                        //temp_square.Add(row[6:9]);
                        for (int i = 6; i < 9; i++)
                        {
                            temp_square.Add(row[i]);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            return temp_square;
        }



        //Create the rows, and columns
        static (Row row, Column col, Square sqr) ConvertInput(List<List<int>> sudokuPuzzle, int indexPosition)
        {
            //Create the column and square lists
            List<int> newColumn = GetColumn(sudokuPuzzle, indexPosition);
            List<int> newSquare = GetSquare(sudokuPuzzle, indexPosition);

            //Find the number of unsolved numbers in each list
            int unsolvedInRow = GetNumberOfUnsolved(sudokuPuzzle[indexPosition]);
            int unsolvedInColumn = GetNumberOfUnsolved(newColumn);
            int unsolvedInSquare = GetNumberOfUnsolved(newSquare);
            
            //Declare row, column and sqare objects
            Row Row = new Row(sudokuPuzzle[indexPosition], indexPosition, false, new List<int>(), unsolvedInRow);

            Column Col = new Column(newColumn, indexPosition, false, new List<int>(), unsolvedInColumn);

            Square Sqr = new Square(newSquare, indexPosition, false, new List<int>(), unsolvedInSquare);

            return (Row, Col, Sqr);
        }



        //Create the reference for the rows and columns
        static Dictionary<Square, List<Row>>  GetRowReference(List<Row> rows, List<Square> squares)
        {
            Dictionary<Square, List<Row>> rowReference = new Dictionary<Square, List<Row>>();
            int squarePosition = 0;

            foreach (Square square in squares)
            {
                //Declare a new empty list for each iteration of the loop
                List<Row> rowList = new List<Row>();
                if (squarePosition < 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        rowList.Add(rows[i]);
                    }
                }
                else if (squarePosition > 2 && squarePosition < 6)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        rowList.Add(rows[i]);
                    }
                }
                else
                {
                    for (int i = 6; i < 9; i++)
                    {
                        rowList.Add(rows[i]);
                    }
                }
                //Add the current square along with the rows it should reference
                rowReference.Add(square, rowList);
                squarePosition++;
            }
            return rowReference;  
        }
        static Dictionary<Square, List<Column>> GetColumnReference(List<Column> columns, List<Square> squares)
        {
            Dictionary<Square, List<Column>> colReference = new Dictionary<Square, List<Column>>();
            int squarePosition = 0;

            foreach (Square square in squares)
            {
                //Declare a new empty list for each iteration of the loop
                List<Column> colList = new List<Column>();
                if (squarePosition % 3 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        colList.Add(columns[i]);
                    }
                }
                else if (squarePosition > 2 && squarePosition < 6)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        colList.Add(columns[i]);
                    }
                }
                else
                {
                    for (int i = 6; i < 9; i++)
                    {
                        colList.Add(columns[i]);
                    }
                }
                //Add the current square along with the columns it should reference
                colReference.Add(square, colList);
                squarePosition++;
            }
            return colReference;
        }



        //Update/Propegate the cahnge to the entire board when a new candidate is inserted
        static (Row row, Column column, Square square) UpdateBoard(Row row, Column column, Square square, int candidateSquareIndex, int candidate)
        {
            square.square[candidateSquareIndex] = candidate;

            return (row, column, square);
        }

        //Get user input / Sudoku puzzle
        static List<List<int>> GetPuzzle()
        {
            List<List<int>> puzzle = new List<List<int>>(); 
            for (int i = 0; i < 9; i++)
            {

            }
        }

        //__main__
        static void Main(string[] args)
        {
            //Suduko Puzzle Input
            var row0 = new List<int> { 0, 0, 2,   0, 7, 0,   0, 1, 0 };
            var row1 = new List<int> { 8, 0, 0,   0, 2, 0,   7, 0, 6 };
            var row2 = new List<int> { 7, 0, 4,   0, 0, 1,   0, 9, 0 };

            var row3 = new List<int> { 1, 0, 0,   0, 0, 0,   0, 0, 0 };
            var row4 = new List<int> { 0, 0, 3,   5, 0, 9,   2, 8, 0 };
            var row5 = new List<int> { 4, 0, 0,   0, 0, 0,   9, 5, 1 };

            var row6 = new List<int> { 0, 0, 6,   0, 0, 0,   1, 3, 0 };
            var row7 = new List<int> { 0, 0, 0,   0, 0, 2,   0, 0, 7 };
            var row8 = new List<int> { 0, 0, 0,   0, 0, 3,   5, 0, 0 };


            //Set up the entire puzzle in nested list
            var mySudokuPuzzle = new List<List<int>> { row0, row1, row2, row3, row4, row5, row6, row7, row8 };


            //Create the puzzle board
            var (Row0, Col0, Sqr0) = ConvertInput(mySudokuPuzzle, 0);
            var (Row1, Col1, Sqr1) = ConvertInput(mySudokuPuzzle, 1);
            var (Row2, Col2, Sqr2) = ConvertInput(mySudokuPuzzle, 2);
            var (Row3, Col3, Sqr3) = ConvertInput(mySudokuPuzzle, 3);
            var (Row4, Col4, Sqr4) = ConvertInput(mySudokuPuzzle, 4);
            var (Row5, Col5, Sqr5) = ConvertInput(mySudokuPuzzle, 5);
            var (Row6, Col6, Sqr6) = ConvertInput(mySudokuPuzzle, 6);
            var (Row7, Col7, Sqr7) = ConvertInput(mySudokuPuzzle, 7);
            var (Row8, Col8, Sqr8) = ConvertInput(mySudokuPuzzle, 8);

            List<Row> sudokuRows = new List<Row> { Row0, Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8 };
            List<Column> sudokuCols = new List<Column> { Col0, Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8 };
            List<Square> sudokuSqrs = new List<Square> { Sqr0, Sqr1, Sqr2, Sqr3, Sqr4, Sqr5, Sqr6 ,Sqr7, Sqr8 };

            Dictionary<Square, List<Row>> rowReference = GetRowReference(sudokuRows, sudokuSqrs);
            Dictionary<Square, List<Column>> colReference = GetColumnReference(sudokuCols, sudokuSqrs);
            //


            //////////////
            var mySudokuRowsList = new List<List<int>> {    Row0.row, Row1.row, Row2.row, 
                                                            Row3.row, Row4.row, Row5.row, 
                                                            Row6.row, Row7.row, Row8.row    };
            var mySudokuColsList = new List<List<int>> {    Col0.column, Col1.column, Col2.column, 
                                                            Col3.column, Col4.column, Col5.column, 
                                                            Col6.column, Col7.column, Col8.column   };
            var mySudokuSqrsList = new List<List<int>> {    Sqr0.square, Sqr1.square, Sqr2.square,
                                                            Sqr3.square, Sqr4.square, Sqr5.square,
                                                            Sqr6.square, Sqr7.square, Sqr8.square,  };

            Console.WriteLine("\n\n\nRows: ");
            MySudokuPrinter(mySudokuRowsList);

            Console.WriteLine("\n\n\nColumns: ");
            MySudokuPrinter(mySudokuColsList);

            Console.WriteLine("\n\n\nSquares: ");
            MySudokuPrinter(mySudokuSqrsList);
            //////////////
        }
    }
}