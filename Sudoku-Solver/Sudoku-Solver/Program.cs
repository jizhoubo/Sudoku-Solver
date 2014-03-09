using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku_Model sudoku = new Sudoku_Model();
            Controller controller = new Controller();

            //int[,] inputSudokuArray = new int[9, 9] 
            //{ 
            //    {4, 5, 9, 0, 0, 0, 1, 7, 8},
            //    {6, 7, 0, 0, 9, 0, 0, 0, 0},
            //    {0, 0, 0, 7, 0, 4, 9, 0, 0},
            //    {9, 0, 3, 4, 0, 0, 0, 8, 0},
            //    {0, 8, 0, 0, 0, 6, 7, 0, 1},
            //    {0, 0, 7, 5, 2, 8, 6, 0, 0},
            //    {0, 0, 6, 8, 0, 2, 0, 0, 0},
            //    {7, 0, 4, 0, 0, 0, 8, 9, 3},
            //    {0, 0, 0, 0, 0, 0, 0, 0, 7}
            //};

            int[,] inputSudokuArray = new int[9, 9] 
            { 
                {0, 5, 0, 0, 7, 1, 0, 8, 0},
                {0, 7, 0, 0, 0, 0, 0, 2, 0},
                {0, 0, 9, 8, 0, 5, 4, 0, 0},
                {0, 0, 7, 6, 0, 0, 0, 0, 4},
                {9, 0, 0, 0, 0, 4, 3, 0, 0},
                {0, 0, 3, 0, 0, 0, 8, 0, 0},
                {0, 0, 2, 5, 0, 8, 6, 0, 0},
                {0, 1, 0, 0, 9, 7, 0, 5, 0},
                {0, 3, 0, 0, 0, 0, 0, 4, 0}
            };


            sudoku.Sudoku = inputSudokuArray;

            //controller.PrintSudoku(sudoku);
            Console.WriteLine();

            if ((controller.SolveSudokuComplete(sudoku)))
            {
                Console.WriteLine("Complete!");
                Console.WriteLine();
                controller.PrintSudoku(controller.FinalSudoku());
            }
            else
            {
                Console.WriteLine("Cannot be resolved!");
            }
            

            Console.ReadLine();
        }
    }

    
}
