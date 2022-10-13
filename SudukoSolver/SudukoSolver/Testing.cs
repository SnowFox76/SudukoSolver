using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        static List<int> GetSquare()
        {

            return new List<int>();
        }


        //Create the rows, and columns
        static List<int> CreateBoard(List<List<int>> sudukoPuzzle)
        {
            var tried = new List<int>();

            //Declare row objects
            Rows Row0 = new Rows(sudukoPuzzle[0], 0, false, tried);
            Rows Row1 = new Rows(sudukoPuzzle[1], 1, false, tried);
            Rows Row2 = new Rows(sudukoPuzzle[2], 2, false, tried);
            Rows Row3 = new Rows(sudukoPuzzle[3], 3, false, tried);
            Rows Row4 = new Rows(sudukoPuzzle[4], 4, false, tried);
            Rows Row5 = new Rows(sudukoPuzzle[5], 5, false, tried);
            Rows Row6 = new Rows(sudukoPuzzle[6], 6, false, tried);
            Rows Row7 = new Rows(sudukoPuzzle[7], 7, false, tried);
            Rows Row8 = new Rows(sudukoPuzzle[8], 8, false, tried);

            Columns Col0 = new Columns(GetColumn(sudukoPuzzle, 0), 0, false, tried);
            Columns Col1 = new Columns(GetColumn(sudukoPuzzle, 1), 1, false, tried);
            Columns Col2 = new Columns(GetColumn(sudukoPuzzle, 2), 2, false, tried);
            Columns Col3 = new Columns(GetColumn(sudukoPuzzle, 3), 3, false, tried);
            Columns Col4 = new Columns(GetColumn(sudukoPuzzle, 4), 4, false, tried);
            Columns Col5 = new Columns(GetColumn(sudukoPuzzle, 5), 5, false, tried);
            Columns Col6 = new Columns(GetColumn(sudukoPuzzle, 6), 6, false, tried);
            Columns Col7 = new Columns(GetColumn(sudukoPuzzle, 7), 7, false, tried);
            Columns Col8 = new Columns(GetColumn(sudukoPuzzle, 8), 8, false, tried);



            return sudukoPuzzle[0];
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
            var myPuzzle = new List<List<int>> { row0, row1, row2, row3, row4, row5, row6, row7, row8 }; 

            Console.Write("The row before solving: ");
            MyPrinter(row1);
            
            RowSolver(row1);
            Console.Write("\nThe row after solving: ");
            MyPrinter(row1);

        }
    }
}