using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Models
{
    internal class MinesweeperModel : IGameModel
    {
        private bool[,] _isOpen = new bool[9, 9];

        public Timer mineSweeperTimer = new Timer();

        private Random rand = new Random();

        private MineSweeperCell[,] _boardLevel = new MineSweeperCell[9, 9];
        public int chosenStatus { get; private set; } = 0;
        public Color cellColor { get; private set; } = Color.White;

        public string cellStatus { get; private set; } = string.Empty;

        private string[] cellStatuses = { "safe", "flag", "mine", "number" };


        public void Reset()
        { 
            chosenStatus = 0;
            for (int i = 0; i < _boardLevel.GetLength(0); i++)
            {
                for (int j = 0; j < _boardLevel.GetLength(1); j++)
                {
                    _boardLevel[i, j] = new MineSweeperCell(i, j);
                    _isOpen[i, j] = false;
                }
            }
        }

        public void MineSweeperCellEditor(MineSweeperCell[,] board)
        {
            foreach (MineSweeperCell cell in board)
            {
                if (cell.status != "mine")
                {
                    cell.CellNumberCalc(board, cell);
                    cell.SetStatus();
                }
            }

        }
        public void GenerateLevel()
        {
            int x = 0;
            int y = 0;
            int numberOfMines = 0;

            do
            {
                x = rand.Next(_boardLevel.GetLength(0));
                y = rand.Next(_boardLevel.GetLength(1));

                _boardLevel[x, y].status = cellStatuses[2];

                numberOfMines++;
            } while (numberOfMines <= 13);

            MineSweeperCellEditor(_boardLevel);
        }

        public bool MakeMove(int x, int y, out Color colorStatus)
        {
            if (!_isOpen[x, y])
            {
                if (chosenStatus == 0)
                {
                    cellStatus = cellStatuses[1];
                    colorStatus = Color.Gray;
                    return true;
                }

                if (_boardLevel[x, y].status == cellStatuses[3])
                {
                    cellStatus = _boardLevel[x, y].number.ToString();
                    colorStatus = Color.White;
                    _isOpen[x, y] = true;
                    return true;
                }
                else if (_boardLevel[x, y].status == cellStatuses[0])
                {
                    RevealSafeArea(x, y);
                    cellStatus = _boardLevel[x, y].status;
                    colorStatus = Color.White;
                    return true;
                }

                cellStatus = _boardLevel[x, y].status;
                colorStatus = Color.White;
                _isOpen[x, y] = true;
                return true;
            }

            colorStatus = Color.White;
            return false;
        }


        private void RevealSafeArea(int x, int y)
        {
            int rows = _boardLevel.GetLength(0);
            int cols = _boardLevel.GetLength(1);

            if (x < 0 || x >= rows || y < 0 || y >= cols) return;
            if (_isOpen[x, y]) return;

            _isOpen[x, y] = true;

            string status = _boardLevel[x, y].status;

            if (status == "number")
            {
                return;
            }

            if (status == "safe")
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;
                        RevealSafeArea(x + dx, y + dy);
                    }
                }
            }
        }


        public List<(int x, int y, string status)> GetOpenedCells()
        {
            var opened = new List<(int, int, string)>();

            for (int i = 0; i < _isOpen.GetLength(0); i++)
            {
                for (int j = 0; j < _isOpen.GetLength(1); j++)
                {
                    if (_isOpen[i, j])
                    {
                        string labelText = _boardLevel[i, j].status;
                        if (labelText == "number")
                            labelText = _boardLevel[i, j].number.ToString();
                        opened.Add((i, j, labelText));
                    }
                }
            }

            return opened;
        }


        public void SetStatus(int x)
        {
            chosenStatus = x;
        }
        public bool CheckWin()
        {
            int allCells = _isOpen.GetLength(0) * _isOpen.GetLength(1);
            int numberOfOpened = 0;
            int mines = 0;

            foreach (MineSweeperCell cell in _boardLevel)
            {
                if (cell.status == cellStatuses[2])
                {
                    mines++;
                }
            }

            foreach (bool isOpened in _isOpen)
            {
                if (isOpened)
                    numberOfOpened++;
            }
            
            return numberOfOpened == allCells - mines;
        }

        public bool CheckLose(int x, int y)
        {
            if (_boardLevel[x, y].status == cellStatuses[2] && _isOpen[x, y] == true)
            {
                return true;
            }

            return false;
        }
    }
}
