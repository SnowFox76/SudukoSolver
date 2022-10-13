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
        //Displays out the list
        static void MyPrinter(List<int> array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            //Console.WriteLine("\n");
        }


        //Suduko Printer
        static void MySudukoPrinter(List<List<int>> myPuzzleLists )
        {
            int loopCount = 0;
            foreach (var myList in myPuzzleLists)
            {
                Console.Write($"\n{loopCount}  :  ");
                MyPrinter(myList);
                loopCount++;
            }
        }


        //Find the slot where the candidate can be inserted and insert the candidate
        static List<int> InsertCadidate(List<int> array, int candidate)
        {
            int open_slot = array.IndexOf(0);
            array[open_slot] = candidate;

            return array;
        }


        //Completes one array
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

        
        //Create the column
        static List<int> GetColumn(List<List<int>> sudukoPuzzle, int columnNumber)
        {
            var temp_column = new List<int>();
            foreach (List<int> row in sudukoPuzzle)
            {
                temp_column.Add(row[columnNumber]);
            }
            
            return temp_column;
        }


        //Create the square
        static List<int> GetSquare(List<List<int>> sudukoPuzzle, int position)
        {
            var temp_square = new List<int>();

            foreach (List<int> row in sudukoPuzzle)
            {
                if (position % 3 == 0)
                {
                    if (sudukoPuzzle.IndexOf(row) == 0 || sudukoPuzzle.IndexOf(row) == 1 || sudukoPuzzle.IndexOf(row) == 2)
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
                    if (sudukoPuzzle.IndexOf(row) == 3 || sudukoPuzzle.IndexOf(row) == 4 || sudukoPuzzle.IndexOf(row) == 5)
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
                    if (sudukoPuzzle.IndexOf(row) == 6 || sudukoPuzzle.IndexOf(row) == 7 || sudukoPuzzle.IndexOf(row) == 8)
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
        static (object row, object col, object sqr) ConvertInput(List<List<int>> sudukoPuzzle, int indexPosition)
        {
            //Declare row, column and sqare objects
            Rows Row = new Rows(sudukoPuzzle[indexPosition], indexPosition, false, new List<int>());

            Columns Col = new Columns(GetColumn(sudukoPuzzle, indexPosition), indexPosition, false, new List<int>());

            Square Sqr = new Square(GetSquare(sudukoPuzzle, indexPosition), indexPosition, false, new List<int>());

            return (Row, Col, Sqr);
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
            var mySudukoPuzzle = new List<List<int>> { row0, row1, row2, row3, row4, row5, row6, row7, row8 };

            //Create the puzzle board
            var (Row0, Col0, Sqr0) = ConvertInput(mySudukoPuzzle, 0);
            var (Row1, Col1, Sqr1) = ConvertInput(mySudukoPuzzle, 1);
            var (Row2, Col2, Sqr2) = ConvertInput(mySudukoPuzzle, 2);
            var (Row3, Col3, Sqr3) = ConvertInput(mySudukoPuzzle, 3);
            var (Row4, Col4, Sqr4) = ConvertInput(mySudukoPuzzle, 4);
            var (Row5, Col5, Sqr5) = ConvertInput(mySudukoPuzzle, 5);
            var (Row6, Col6, Sqr6) = ConvertInput(mySudukoPuzzle, 6);
            var (Row7, Col7, Sqr7) = ConvertInput(mySudukoPuzzle, 7);
            var (Row8, Col8, Sqr8) = ConvertInput(mySudukoPuzzle, 8);

            var mySudukoRows = new List<List<int>> {    (Row0 as dynamic).row, 
                                                        (Row1 as dynamic).row, 
                                                        (Row2 as dynamic).row,
                                                        (Row3 as dynamic).row,
                                                        (Row4 as dynamic).row,
                                                        (Row5 as dynamic).row,
                                                        (Row6 as dynamic).row,
                                                        (Row7 as dynamic).row,
                                                        (Row8 as dynamic).row
                                                    };
            var mySudukoCols = new List<List<int>> {    (Col0 as dynamic).column,
                                                        (Col1 as dynamic).column,
                                                        (Col2 as dynamic).column,
                                                        (Col3 as dynamic).column,
                                                        (Col4 as dynamic).column,
                                                        (Col5 as dynamic).column,
                                                        (Col6 as dynamic).column,
                                                        (Col7 as dynamic).column,
                                                        (Col8 as dynamic).column
                                                    };
            var mySudukoSqrs = new List<List<int>> {    (Sqr0 as dynamic).square,
                                                        (Sqr1 as dynamic).square,
                                                        (Sqr2 as dynamic).square,
                                                        (Sqr3 as dynamic).square,
                                                        (Sqr4 as dynamic).square,
                                                        (Sqr5 as dynamic).square,
                                                        (Sqr6 as dynamic).square,
                                                        (Sqr7 as dynamic).square,
                                                        (Sqr8 as dynamic).square
                                                    };

            Console.WriteLine("\n\n\nRows: ");
            MySudukoPrinter(mySudukoRows);
            Console.WriteLine("\n\n\nColumns: ");
            MySudukoPrinter(mySudukoCols);
            Console.WriteLine("\n\n\nSquares: ");
            MySudukoPrinter(mySudukoSqrs);

            /*Console.Write("The row before solving: ");
            MyPrinter(row1);
            
            RowSolver(row1);
            Console.Write("\nThe row after solving: ");
            MyPrinter(row1);*/

        }
    }
}