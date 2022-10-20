using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    public  class MyMiscMethods
    {
        //Displays out a list
        public static void MyPrinter(List<int> array, int indexNumber)
        {
            Console.Write($"\n{indexNumber}: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }


        //Displays the Columns, Rows and Squares
        public static void MySudokuPrinter(List<Row> sudokuRows, List<Column> sudokuCols, List<Square> sudokuSqrs, string whenDoIRun)
        {
            Console.WriteLine(whenDoIRun);
            Console.Write("\n\nRows:");
            foreach (Row row in sudokuRows)
            {
                MyPrinter(row.row, row.rowNumber);
            }
            Console.Write("\n\nColumns:");
            foreach (Column col in sudokuCols)
            {
                MyPrinter(col.column, col.columnNumber);
            }
            Console.Write("\n\nSquares:");
            foreach (Square square in sudokuSqrs)
            {
                MyPrinter(square.square, square.position);
            }
            Console.WriteLine("\n\n");

        }


        //Get the number of unsolved numbers in a list
        public static int GetNumberOfUnsolved(List<int> array)
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


        //Get total number of unsolved in puzzle
        public static int GetTotalUnsolved(List<Square> Squares)
        {
            int total = 0;

            foreach (Square square in Squares)
            {
                total += square.unsolved;
            }

            return total;
        }
    }
}
