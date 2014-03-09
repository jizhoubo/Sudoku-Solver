Sudoku-Solver

This small project is written in C#, to solve Sudoku puzzles

===================================
Structure:
  1. Sudoku_Model.cs
    - describes model of Sudoku, containing a two-dimension int array (Sudoku) as Sudoku to work on, a dictionary<int, List<int>> (Candidates) to save possible values of empty squares of the Sudoku array
  2. Contoller.cs
    - contains functions to solve the Sudoku puzzle
    - SolveSudokuBasic is to fill up empty squares which can only have one value, decided by checking same row, same col and same 3X3 box, and will also fill up 
    - SolveSudokuComplete is to solve all sudoku puzzles.  It first call SolveSudokuBasic, and if SolveSudokuBasic not able to complete the puzzle, will use function GetSquareWithLeastCandidates to get the square which having least candidate values, and fill in the Sudoku array with the value, and call back SolveSudokuComplete
     
===================================
Tested with 2 test cases:

            int[,] inputSudokuArray = new int[9, 9] 
            { 
                {4, 5, 9, 0, 0, 0, 1, 7, 8},
                {6, 7, 0, 0, 9, 0, 0, 0, 0},
                {0, 0, 0, 7, 0, 4, 9, 0, 0},
                {9, 0, 3, 4, 0, 0, 0, 8, 0},
                {0, 8, 0, 0, 0, 6, 7, 0, 1},
                {0, 0, 7, 5, 2, 8, 6, 0, 0},
                {0, 0, 6, 8, 0, 2, 0, 0, 0},
                {7, 0, 4, 0, 0, 0, 8, 9, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 7}
            };
            
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

