
namespace GamesApp
{
    internal class MineSweeperCell
    {
        public string status { get; set; }
        public int number { get; private set; }

        private int xCoordinate;
        private int yCoordinate;
        public MineSweeperCell(int xCoordinate, int yCoordinate)
        {
            status = "empty";
            number = 0;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

 

        public void CellNumberCalc(MineSweeperCell[,] board, MineSweeperCell cell)
        {
            int x = (cell.xCoordinate > 0) ? cell.xCoordinate - 1 : cell.xCoordinate;
            int y = (cell.yCoordinate > 0) ? cell.yCoordinate - 1 : cell.yCoordinate;
            int borderX = (cell.xCoordinate < board.GetLength(0)) ? cell.xCoordinate + 1 : cell.xCoordinate;
            int borderY = (cell.yCoordinate < board.GetLength(1)) ? cell.xCoordinate + 1 : cell.xCoordinate;

            for (int i = x; i < borderX; i++)
            {
                for (int j = y; j < borderY; j++)
                {
                    if (board[i,j].status == "safe")
                    {
                        cell.number++;
                    }
                }
            }
        }

        public void SetStatus()
        {
            if (number > 0)
            {
                status = "number";
            }
        }
    }
}
