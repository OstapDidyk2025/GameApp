using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

namespace GamesApp.Models
{
    internal class SudokuModel : IGameModel
    {

        public Timer sudokuTimer = new Timer();

        private Random rand = new Random();

        private int[,] _boardStart = new int[9, 9]
        { {1,2,3,4,5,6,7,8,9},
            {4,5,6,7,8,9,1,2,3},
            {7,8,9,1,2,3,4,5,6},
            {2,3,4,5,6,7,8,9,1},
            {5,6,7,8,9,1,2,3,4},
            {8,9,1,2,3,4,5,6,7},
            {3,4,5,6,7,8,9,1,2},
            {6,7,8,9,1,2,3,4,5},
            {9,1,2,3,4,5,6,7,8} };

        private int[,] _boardLevel = new int[9, 9];

        private bool[,] _isRightNumber = new bool[9, 9];
        public int chosenNumber { get; private set; } = 0;
        public Color cellColor { get; private set; } = Color.White;
        public int mistakes { get; private set; } = 0;



        public int[,] GenerateLevel()
        {
            int numberOfDigits;
            int x;
            int y;
            bool[,] isFilled = new bool[_boardStart.GetLength(0), _boardStart.GetLength(1)];


            for (int i = 0; i <= 9; i++)
            {
                numberOfDigits = rand.Next(1, 6);

                do
                {
                    
                    x = rand.Next(_boardLevel.GetLength(0));
                    y = rand.Next(_boardLevel.GetLength(1));


                    if (isFilled[x, y] == false)
                    {
                        _boardLevel[x, y] = _boardStart[x, y];
                        _isRightNumber[x, y] = true;
                        isFilled[x, y] = true; 
                        numberOfDigits--;
                    }


                } while (numberOfDigits != 0);


            }

            return _boardLevel;
        }


        public void GenerateGreed()
        {
            int changesPoint = 0;
            int firstNumber;
            int secondNumber;
            int change;

            do
            {
                firstNumber = rand.Next(_boardStart.GetLength(0));
                secondNumber = rand.Next(_boardStart.GetLength(1));

                change = rand.Next(4);

                if (firstNumber != secondNumber)
                {
                    if (firstNumber / 3 == secondNumber / 3 && (change < 2))
                    {
                        if (change == 0)
                        {
                            SwapColumn(firstNumber, secondNumber);
                        }
                        else
                        {
                            SwapRow(firstNumber, secondNumber);
                        }
                        changesPoint++;

                    }
                    else
                    {
                        if (change == 2)
                        {
                            SwapRowBlocks(firstNumber / 3, secondNumber  / 3);
                        }
                        else 
                        {
                            SwapColumnBlocks(firstNumber / 3, secondNumber / 3);
                        }
                    }
                }

            } while (changesPoint < 100);


        }

        private void SwapRow(int fRow, int sRow)
        {
            int[] forChange = new int[9];

            for (int i = 0; i < 9; i++)
            {
                forChange[i] = _boardStart[i, fRow];
                _boardStart[i, fRow] = _boardStart[i, sRow];
                _boardStart[i, sRow] = forChange[i];
            }
        }
        private void SwapRowBlocks(int block1, int block2)
        {
            for (int i = 0; i < 3; i++)
            {
                int row1 = block1 * 3 + i;
                int row2 = block2 * 3 + i;

                for (int col = 0; col < 9; col++)
                {
                    int temp = _boardStart[row1, col];
                    _boardStart[row1, col] = _boardStart[row2, col];
                    _boardStart[row2, col] = temp;
                }
            }
        }

        private void SwapColumnBlocks(int block1, int block2)
        {
            for (int i = 0; i < 3; i++)
            {
                int col1 = block1 * 3 + i;
                int col2 = block2 * 3 + i;

                for (int row = 0; row < 9; row++)
                {
                    int temp = _boardStart[row, col1];
                    _boardStart[row, col1] = _boardStart[row, col2];
                    _boardStart[row, col2] = temp;
                }
            }
        }


        private void SwapColumn(int fColumn, int sColumn)
        {
            int[] forChange = new int[9];

            for (int i = 0; i < 9; i++)
            {
                forChange[i] = _boardStart[fColumn, i];
                _boardStart[fColumn, i] = _boardStart[sColumn, i];
                _boardStart[sColumn, i] = forChange[i];
            }
        }

        public bool MakeMove(int x, int y, out Color color)
        {
            if (_boardLevel[x, y] != 0 && _isRightNumber[x,y] == true)
            {
                color = cellColor;
                return false;
            }

            RightMoveCheck(x, y);

            color = cellColor;
            return true;
        }

        private void RightMoveCheck(int x, int y)
        {
            if (chosenNumber != 0)
            {
                _boardLevel[x, y] = Convert.ToInt32(chosenNumber);

                if (_boardLevel[x, y] != _boardStart[x, y])
                {
                    cellColor = Color.Salmon;
                    mistakes++;
                    return;

                }

                _isRightNumber[x, y] = true;
                cellColor = Color.LightGreen;
            }
            else
            {
                cellColor = Color.White;
            }
        }


        public void SetNumber(int x)
        {
            chosenNumber = x;
        }

        public bool CheckLose()
        {
            bool status = (mistakes == 5) ? true : false;
            return status;
        }

        public bool CheckWin() 
        {
            for (int i = 0; i < _boardLevel.GetLength(0); i++)
            {
                for (int j = 0; j < _boardLevel.GetLength(1); j++)
                {
                    if (_boardLevel[i,j] != _boardStart[i,j] && _isRightNumber[i,j] != true)
                        return false;
                }
            }
            return true;
        }

        public void Reset() 
        {
            sudokuTimer.Start();
            mistakes = 0;
            _boardLevel = new int[9, 9];
            for (int i = 0; i < _boardLevel.GetLength(0); i++)
            {
                for (int j = 0; j < _boardLevel.GetLength(1); j++)
                { 
                    _boardLevel[i, j] = 0;
                    _isRightNumber[i, j] = false;
                }
            }
        }
    }
}
