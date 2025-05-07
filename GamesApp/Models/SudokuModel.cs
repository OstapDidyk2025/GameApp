using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Models
{
    internal class SudokuModel : IGameModel
    {

        Random rand = new Random();
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
        public string chosenNumber { get; private set; } = " ";
        public Color cellColor { get; private set; } = Color.White;

        public int[,] GenerateLevel()
        {
            int showedCells = 0;
            int x;
            int y;

            do
            {
                x = rand.Next(_boardLevel.GetLength(0));
                y = rand.Next(_boardLevel.GetLength(1));

                _boardLevel[x, y] = _boardStart[x, y];
                _isRightNumber[x, y] = true;

                showedCells++;
            } while (showedCells < 35);

            return _boardLevel;
        }

        public void GenerateGreed()
        {
            int changesPoint = 0;
            int firstNumber;
            int secondNumber;

            do
            {
                firstNumber = rand.Next(_boardStart.GetLength(0));
                secondNumber = rand.Next(_boardStart.GetLength(1));

                if (firstNumber / 3 == secondNumber / 3)
                {
                    if (firstNumber != secondNumber)
                    {
                        if (rand.Next(2) == 0)
                        {
                            SwapColumns(firstNumber, secondNumber);
                        }
                        else
                        {
                            SwapRows(firstNumber, secondNumber);
                        }
                        changesPoint++;
                    }
                }
            } while (changesPoint < 60);


        }

        private void SwapRows(int fRow, int sRow)
        {
            int[] forChange = new int[9];

            for (int i = 0; i < 9; i++)
            {
                forChange[i] = _boardStart[i, fRow];
                _boardStart[i, fRow] = _boardStart[i, sRow];
                _boardStart[i, sRow] = forChange[i];
            }
        }

        private void SwapColumns(int fColumn, int sColumn)
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
            if (chosenNumber != " ")
            {
                _boardLevel[x, y] = Convert.ToInt32(chosenNumber);

                if (_boardLevel[x, y] != _boardStart[x, y])
                {
                    cellColor = Color.Red;
                    return;

                }

                _isRightNumber[x, y] = true;
                cellColor = Color.Aqua;
            }
            else
            {
                cellColor = Color.White;
            }
        }


        public void SetNumber(int x)
        {
            if (x == 0)
            {
                chosenNumber = " ";
            }
            else 
            {
                chosenNumber = x.ToString();
            }
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
