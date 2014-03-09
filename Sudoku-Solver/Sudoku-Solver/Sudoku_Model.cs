using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku_Solver
{
    class Sudoku_Model
    {
        private int[,] _Sudoku = new int[9,9];
        public int[,] Sudoku
        {
            get
            {
                return _Sudoku;
            }
            set
            {
                _Sudoku = value;
            }
        }
        
        private Dictionary<int, List<int>> _Candidates = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> Candidates 
        { 
            get
            {
                return _Candidates;
            }
            set
            {
                _Candidates = value;
            } 
        }



        //public List<int> GetNumbersAllowed(int hpos, int vpos, int[,] inputSudoku)
        //{
        //    List<int> returnedList = new List<int>();
        //    Dictionary<int, bool> appearedNumbers = new Dictionary<int, bool>();
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        appearedNumbers.Add(i, false);
        //    }

        //    //horizontal
        //    for (int i = 0; i < 9; i++)
        //    {
        //        appearedNumbers[_Sudoku[i, vpos]] = true;
        //    }

        //    //vertical
        //    for (int i = 0; i < 9; i++)
        //    {
        //        appearedNumbers[_Sudoku[hpos, i]] = true;
        //    }

        //    //small 3X3
        //    for (int i = (hpos/3)*3; i < (hpos/3)*3+3 ; i++)
        //    {
        //        for (int j = (vpos/3)*3; j < (vpos/3)*3+3; j++)
        //        {
        //            appearedNumbers[_Sudoku[i, j]] = true;
        //        }

        //    }

        //    //get not appeared numbers and return
        //    foreach (KeyValuePair<int, bool> e in appearedNumbers)
        //    {
        //        if (!e.Value)
        //        {
        //            returnedList.Add(e.Key);
        //        }
        //    }

        //    return returnedList;
        //}

        //public bool SolveSudokuBasic(int[,] inputSudoku)
        //{
        //    bool stillChanging = true;
            
        //    while (stillChanging)
        //    {
        //        for (int i = 0; i < 9; i++)
        //        {
        //            for (int j = 0; j < 9; j++)
        //            {
        //                if (inputSudoku[i, j] != 0)
        //                {
        //                    continue;
        //                }
        //                List<int> tmpCandidates = new List<int>();
        //                tmpCandidates = GetNumbersAllowed(i, j, inputSudoku);
        //                if (tmpCandidates.Count == 1)
        //                {
        //                    inputSudoku[i, j] = tmpCandidates[0];
        //                    stillChanging = true;
        //                }
        //                else if (tmpCandidates.Count > 1)
        //                {
        //                    candidates.Add(i * 10 + j, tmpCandidates);
        //                    stillChanging = false;
        //                }
        //                else
        //                {
        //                    this.PrintSudoku(inputSudoku);
        //                    return false;
        //                }

        //            }
        //        }
        //    }
        //    _Sudoku = 
        //    return true;
        //}

        //public bool SolveSudokuComplex()
        //{
        //    while (candidates.Count > 0)
        //    {
        //        foreach (KeyValuePair<int, List<int>> kvp in candidates)
        //        {
        //            int key = kvp.Key;
        //            foreach (int element in candidates[key])
        //            {
        //                //int[,] guessSudoku = new int[9, 9];
        //                //Array.Copy(_Sudoku, guessSudoku, _Sudoku.Length);
        //                //guessSudoku[key/10, key%10] = element;
        //                int originalValue = _Sudoku[key / 10, key % 10];
        //                _Sudoku[key/10, key%10] = element;
        //                if (SolveSudokuBasic())
        //                {
        //                    PrintSudoku();
        //                }
        //                else
        //                {

        //                }
        //            }
        //        }
        //    }
            
        //    return false;
        //}

        //public void InitSudoku (int[,] sudoku)
        //{
        //    _Sudoku = sudoku;
        //}

        //public void PrintSudoku(int[,] inputSudoku)
        //{
        //    for (int i = 8; i >= 0; i--)
        //    {
        //        for (int j = 0; j < 9; j++)
        //        {
        //            Console.Write(inputSudoku[i, j].ToString() + " ");
        //        }
        //        Console.WriteLine("");
        //    }
        //}

    }
}
