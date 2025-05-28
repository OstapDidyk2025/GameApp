using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Models
{
    internal class MinesweeperModel : IGameModel
    {

        public Timer minesweeperTimer = new Timer();

        private Random rand = new Random();

        private MineSweeperCell[,] _boardLevel = new MineSweeperCell[9, 9];
        public int chosenStatus { get; private set; } = 0;
        public Color cellColor { get; private set; } = Color.White;

        private string[] cellStatus = {"safe", "flag", "mine", "number"};

        public void Reset()
        { 
            chosenStatus = 0;
            for (int i = 0; i < _boardLevel.GetLength(0); i++)
            {
                for (int j = 0; j < _boardLevel.GetLength(1); j++)
                {
                    _boardLevel[i, j] = new MineSweeperCell(i, j);
                }
            }
        }

        public void MineSweeperCellEditor(MineSweeperCell[,] board)
        {
            foreach (MineSweeperCell cell in board)
            {
                if (cell.status != "mine")
                {
                    cell.SetStatus();
                    cell.CellNumberCalc(board, cell);
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

                _boardLevel[x, y].status = cellStatus[2];

                numberOfMines++;
            } while (numberOfMines <= 15);

            MineSweeperCellEditor(_boardLevel);
        }

        public bool MakeMove(int x, int y, out Color colorStatus)
        {
            colorStatus = Color.White;
            return true;
        }

        public bool CheckWin()
        {
            return true;
        }
    }
}
