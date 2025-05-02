
namespace GamesApp.Models
{
    internal class TicTacToeModel : IGameModel, IpvcMode
    {
        private string[,] board = new string[3, 3];
        public string CurrentPlayer { get; private set; } = "X";
        public Color BoardColor { get; private set; } = Color.Blue;

        public bool MakeMove(int x, int y, out Color color)
        {
            color = BoardColor;
            if (board[x, y] != " ") return false;
            board[x, y] = CurrentPlayer;
            return true;
        }

        public bool ComputerMove(out int a, out int b, out Color botColor)
        {

            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == CurrentPlayer) && (board[i, 1] == CurrentPlayer) && (board[i, 2] == " "))
                {
                    botColor = BoardColor;
                    return MakeMove(a = i, b = 2, out var color);
                }
                else if ((board[i, 0] == CurrentPlayer) && (board[i, 1] == " ") && (board[i, 2] == CurrentPlayer))
                {
                    botColor = BoardColor;
                    return MakeMove(a = i, b = 1, out var color);
                }
                else if ((board[i, 0] == " ") && (board[i, 1] == CurrentPlayer) && (board[i, 2] == CurrentPlayer))
                {
                    botColor = BoardColor;
                    return MakeMove(a = i, b = 0, out var color);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if ((board[0, i] == CurrentPlayer) && (board[1, i] == CurrentPlayer) && (board[2, i] == " "))
                {
                    botColor = BoardColor;
                    return MakeMove(a = 2, b = i, out var color);
                }
                else if ((board[0, i] == CurrentPlayer) && (board[1, i] == " ") && (board[2, i] == CurrentPlayer))
                {
                    botColor = BoardColor;
                    return MakeMove(a = 1, b = i, out var color);
                }
                else if ((board[0, i] == " ") && (board[1, i] == CurrentPlayer) && (board[2, i] == CurrentPlayer))
                {
                    botColor = BoardColor;
                    return MakeMove(a = 0,b = i, out var color);
                }
            }

            if (board[0, 0] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 2] == " ")
            {
                botColor = BoardColor;
                return MakeMove(a = 2, b = 2, out var color);
            }
            if (board[2, 0] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[0, 2] == " ")
            {
                botColor = BoardColor;
                return MakeMove(a = 0, b = 2, out var color);
            }
            if ((board[0, 0] == CurrentPlayer && board[1, 1] == " " && board[2, 2] == CurrentPlayer) ||
                (board[2, 0] == CurrentPlayer && board[1, 1] == " " && board[0, 2] == CurrentPlayer))
            {
                botColor = BoardColor;
                return MakeMove(a = 1, b = 1, out var color);
            }
            if (board[0, 0] == " " && board[1, 1] == CurrentPlayer && board[2, 2] == CurrentPlayer)
            {
                botColor = BoardColor;
                return MakeMove(a = 0, b = 0, out var color);
            }
            if (board[2, 0] == " " && board[1, 1] == CurrentPlayer && board[0, 2] == CurrentPlayer)
            {
                botColor = BoardColor;
                return MakeMove(a = 2, b = 0, out var color);
            }


            if (board[1, 1] == " ")
            {
                botColor = BoardColor;
                return MakeMove(a = 1, b = 1, out var color);
            }

            for (int i = 0; i < 3; i += 2)
            {
                for (int j = 0; j < 3; j += 2)
                {
                    if (board[i, j] == " ")
                    {
                        botColor = BoardColor;
                        return MakeMove(a = i, b = j, out var color);
                    }
                }
            }

            for (int j = 0; j < 3; j += 2)
            {
                if (board[1, j] == " ")
                {
                    botColor = BoardColor;
                    return MakeMove(a = 1, b = j, out var color);
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                if (board[i, 1] == " ")
                {
                    botColor = BoardColor;
                    return MakeMove(a = i, b = 1, out var color);
                }
            }

            a = 0;
            b = 0;
            botColor = BoardColor;
            return false;

        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
                if (board[i, 0] == CurrentPlayer && board[i, 1] == CurrentPlayer && board[i, 2] == CurrentPlayer) return true;

            for (int j = 0; j < 3; j++)
                if (board[0, j] == CurrentPlayer && board[1, j] == CurrentPlayer && board[2, j] == CurrentPlayer) return true;

            if (board[0, 0] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 2] == CurrentPlayer) return true;
            if (board[0, 2] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 0] == CurrentPlayer) return true;

            return false;
        }

        public bool IsDraw()
        {
            foreach (var cell in board)
                if (cell == " ") return false;
            return true;
        }

        public void SwitchPlayer()
        {
            BoardColor = (CurrentPlayer == "X") ? Color.FromArgb(192, 0, 0) : Color.FromArgb(0, 0, 192);
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
        }

        public void Reset()
        {
            board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = " ";
                }
            }
            CurrentPlayer = "X";
            BoardColor = Color.FromArgb(0, 0, 192);
        }
    }
}
