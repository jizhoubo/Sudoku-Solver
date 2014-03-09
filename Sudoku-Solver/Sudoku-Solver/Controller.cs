using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku_Solver
{
    class Controller
    {
        private Stack<Sudoku_Model> _SudokuStack = new Stack<Sudoku_Model>();
        public Stack<Sudoku_Model> SudokuStack 
        {
            get
            {
                return _SudokuStack;
            }

            set
            {
                _SudokuStack = value;
            }
        }
        
        public bool SolveSudokuBasic(Sudoku_Model inputSudoku)
        {
            bool stillChanging = true;
            
            while (stillChanging)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (inputSudoku.Sudoku[i, j] != 0)
                        {
                            continue;
                        }
                        List<int> tmpCandidates = new List<int>();
                        tmpCandidates = GetNumbersAllowed(i, j, inputSudoku.Sudoku);
                        if (tmpCandidates.Count == 1)
                        {
                            inputSudoku.Sudoku[i, j] = tmpCandidates[0];
                            stillChanging = true;
                        }
                        else if (tmpCandidates.Count > 1)
                        {
                            if (!inputSudoku.Candidates.ContainsKey(i * 10 + j))
                            {
                                inputSudoku.Candidates.Add(i * 10 + j, tmpCandidates);
                            }
                            
                            stillChanging = false;
                        }
                        else
                        {
                            //this.PrintSudoku(inputSudoku);
                            return false;
                        }

                    }
                }

                if (IsSudokuComplete(inputSudoku))
                {
                    return true;
                }
            }
            return true;
        }

        public bool IsSudokuComplete(Sudoku_Model inputSudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (inputSudoku.Sudoku[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<int> GetNumbersAllowed(int hpos, int vpos, int[,] inputSudoku)
        {
            List<int> returnedList = new List<int>();
            Dictionary<int, bool> appearedNumbers = new Dictionary<int, bool>();
            for (int i = 1; i <= 9; i++)
            {
                appearedNumbers.Add(i, false);
            }

            //horizontal
            for (int i = 0; i < 9; i++)
            {
                appearedNumbers[inputSudoku[i, vpos]] = true;
            }

            //vertical
            for (int i = 0; i < 9; i++)
            {
                appearedNumbers[inputSudoku[hpos, i]] = true;
            }

            //small 3X3
            for (int i = (hpos / 3) * 3; i < (hpos / 3) * 3 + 3; i++)
            {
                for (int j = (vpos / 3) * 3; j < (vpos / 3) * 3 + 3; j++)
                {
                    appearedNumbers[inputSudoku[i, j]] = true;
                }

            }

            //get not appeared numbers and return
            foreach (KeyValuePair<int, bool> e in appearedNumbers)
            {
                if (!e.Value)
                {
                    returnedList.Add(e.Key);
                }
            }

            return returnedList;
        }

        public void PrintSudoku(Sudoku_Model inputSudoku)
        {
            for (int i = 8; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(inputSudoku.Sudoku[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }        
        
        public bool SolveSudokuComplete(Sudoku_Model inputSudoku)
        {
            if (SolveSudokuBasic(inputSudoku))
            {
                PrintSudoku(inputSudoku);
                if (IsSudokuComplete(inputSudoku))
                {
                    SudokuStack.Push(inputSudoku);
                    return true;
                }
                else
                {
                    int squareWithMinPossibilites = 0;
                    squareWithMinPossibilites = GetSquareWithLeastCandidates(inputSudoku);
                    foreach (int element in inputSudoku.Candidates[squareWithMinPossibilites])
                    {
                        Sudoku_Model guessSudoku = new Sudoku_Model();
                        Array.Copy(inputSudoku.Sudoku, guessSudoku.Sudoku, inputSudoku.Sudoku.Length);
                        guessSudoku.Sudoku[squareWithMinPossibilites / 10, squareWithMinPossibilites % 10] = element;
                        SudokuStack.Push(guessSudoku);
                        Console.WriteLine("Trying: " + squareWithMinPossibilites.ToString() + " with " + element.ToString());
                        if (SolveSudokuComplete(guessSudoku))
                        {
                            return true;
                        }
                        else
                        {
                            SudokuStack.Pop();
                            continue;
                        }
                    }
                    
                }
            }

            return false;
        }

        public int GetSquareWithLeastCandidates(Sudoku_Model inputSudoku)
        {
            int minPossibilities = 9;
            int squareWithMinPossibilites = 0;
            foreach (KeyValuePair<int, List<int>> kvp in inputSudoku.Candidates)
            {
                if (minPossibilities > kvp.Value.Count)
                {
                    minPossibilities = kvp.Value.Count;
                    squareWithMinPossibilites = kvp.Key;
                }
            }
            return squareWithMinPossibilites;
        }

        public Sudoku_Model FinalSudoku()
        {
            return SudokuStack.Pop();
        }
    }
}
