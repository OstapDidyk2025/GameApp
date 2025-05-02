
using System.Security.Cryptography;

namespace GamesApp.Models
{
    internal class TicTacToeNewVersionModel : IGameModel, IpvcMode
    {
        public Color BackColor { get; set; } = Color.FromArgb(0, 0, 192);
        public CellInfo[,] board = new CellInfo[3, 3];
        public string CurrentPlayer { get; private set; } = "X";

        List<(int, int)[]> winningLines = new List<(int, int)[]> 
        {
        new[] { (0,0), (0,1), (0,2) },
        new[] { (1,0), (1,1), (1,2) },
        new[] { (2,0), (2,1), (2,2) },
        new[] { (0,0), (1,0), (2,0) }, 
        new[] { (0,1), (1,1), (2,1) },
        new[] { (0,2), (1,2), (2,2) },
        new[] { (0,0), (1,1), (2,2) }, 
        new[] { (0,2), (1,1), (2,0) },
        };



        public bool MakeMove(int x, int y, out Color color)
        {
            color = BackColor;
            if (board[x, y].text != " ") return false;
            color = BackColor;
            board[x, y].text = CurrentPlayer;
            board[x, y].movesRemaind = 6;
            return true;
        }

        public bool ComputerMove(out int a, out int b, out Color botColor)
        {
            /*for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0].text == CurrentPlayer) && (board[i, 1].text == CurrentPlayer) && (board[i, 2].text == " "))
                {
                    botColor = BackColor;
                    return MakeMove(a = i, b = 2, out var color);
                }
                else if ((board[i, 0].text == CurrentPlayer) && (board[i, 1].text == " ") && (board[i, 2].text == CurrentPlayer))
                {
                    botColor = BackColor;
                    return MakeMove(a = i, b = 1, out var color);
                }
                else if ((board[i, 0].text == " ") && (board[i, 1].text == CurrentPlayer) && (board[i, 2].text == CurrentPlayer))
                {
                    botColor = BackColor;
                    return MakeMove(a = i, b = 0, out var color);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if ((board[0, i].text == CurrentPlayer) && (board[1, i].text == CurrentPlayer) && (board[2, i].text == " "))
                {
                    botColor = BackColor;
                    return MakeMove(a = 2, b = i, out var color);
                }
                else if ((board[0, i].text == CurrentPlayer) && (board[1, i].text == " ") && (board[2, i].text == CurrentPlayer))
                {
                    botColor = BackColor;
                    return MakeMove(a = 1, b = i, out var color);
                }
                else if ((board[0, i].text == " ") && (board[1, i].text == CurrentPlayer) && (board[2, i].text == CurrentPlayer))
                {
                    botColor = BackColor;
                    return MakeMove(a = 0, b = i, out var color);
                }
            }

            if (board[0, 0].text == CurrentPlayer && board[1, 1].text == CurrentPlayer && board[2, 2].text == " ")
            {
                botColor = BackColor;
                return MakeMove(a = 2, b = 2, out var color);
            }
            if (board[2, 0].text == CurrentPlayer && board[1, 1].text == CurrentPlayer && board[0, 2].text == " ")
            {
                botColor = BackColor;
                return MakeMove(a = 0, b = 2, out var color);
            }
            if ((board[0, 0].text == CurrentPlayer && board[1, 1].text == " " && board[2, 2].text == CurrentPlayer) ||
                (board[2, 0].text == CurrentPlayer && board[1, 1].text == " " && board[0, 2].text == CurrentPlayer))
            {
                botColor = BackColor;
                return MakeMove(a = 1, b = 1, out var color);
            }
            if (board[0, 0].text == " " && board[1, 1].text == CurrentPlayer && board[2, 2].text == CurrentPlayer)
            {
                botColor = BackColor;
                return MakeMove(a = 0, b = 0, out var color);
            }
            if (board[2, 0].text == " " && board[1, 1].text == CurrentPlayer && board[0, 2].text == CurrentPlayer)
            {
                botColor = BackColor;
                return MakeMove(a = 2, b = 0, out var color);
            }


            if (board[1, 1].text == " ")
            {
                botColor = BackColor;
                return MakeMove(a = 1, b = 1, out var color);
            }

            for (int i = 0; i < 3; i += 2)
            {
                for (int j = 0; j < 3; j += 2)
                {
                    if (board[i, j].text == " ")
                    {
                        botColor = BackColor;
                        return MakeMove(a = i, b = j, out var color);
                    }
                }
            }

            for (int j = 0; j < 3; j += 2)
            {
                if (board[1, j].text == " ")
                {
                    botColor = BackColor;
                    return MakeMove(a = 1, b = j, out var color);
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                if (board[i, 1].text == " ")
                {
                    botColor = BackColor;
                    return MakeMove(a = i, b = 1, out var color);
                }
            }

            a = 0;
            b = 0;
            botColor = BackColor;
            return false;*/

            string opponent = (CurrentPlayer == "X")? "O" : "X";
            bool CheckMove = false;

            do {
                foreach (var line in winningLines)
                {
                    var texts = line.Select(pos => board[pos.Item1, pos.Item2].text).ToArray();
                    if (texts.Count(t => t == CurrentPlayer) == 2 && texts.Count(t => t == " ") == 1)
                    {
                        var empty = line.First(pos => board[pos.Item1, pos.Item2].text == " ");
                        botColor = BackColor;
                        return CheckMove = MakeMove(a = empty.Item1, b = empty.Item2, out var color);
                    }
                }

                foreach (var line in winningLines)
                {
                    var texts = line.Select(pos => board[pos.Item1, pos.Item2].text).ToArray();
                    if (texts.Count(t => t == opponent) == 2 && texts.Count(t => t == " ") == 1)
                    {
                        var empty = line.First(pos => board[pos.Item1, pos.Item2].text == " ");
                        botColor = BackColor;
                        return CheckMove = MakeMove(a = empty.Item1, b = empty.Item2, out var color);
                    }
                }

                if (board[1, 1].text == " ")
                {
                    botColor = BackColor;
                    return CheckMove = MakeMove(a = 1, b = 1, out var color);
                }

                foreach (var (i, j) in new[] { (0, 0), (0, 2), (2, 0), (2, 2) })
                {
                    if (board[i, j].text == " ")
                    {
                        botColor = BackColor;
                        return CheckMove = MakeMove(a = i, b = j, out var color);
                    }
                }

                foreach (var (i, j) in new[] { (1, 0), (0, 1), (2, 1), (1, 2) })
                {
                    if (board[i, j].text == " ")
                    {
                        a = i; b = j;
                        botColor = BackColor;
                        return CheckMove = MakeMove(i, j, out var color);
                    }
                }
            } while (CheckMove == false);

            a = 0; b = 0;
            botColor = BackColor;
            return CheckMove;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
                if ((board[i, 0].text == CurrentPlayer) && (board[i, 1].text == CurrentPlayer) && (board[i, 2].text == CurrentPlayer)) return true;
            for (int i = 0; i < 3; i++)
                if ((board[0, i].text == CurrentPlayer) && (board[1, i].text == CurrentPlayer) && (board[2, i].text == CurrentPlayer)) return true;

            if ((board[0, 0].text == CurrentPlayer) && (board[1, 1].text == CurrentPlayer) && (board[2, 2].text == CurrentPlayer)) return true;

            if ((board[2, 0].text == CurrentPlayer) && (board[1, 1].text == CurrentPlayer) && (board[0, 2].text  == CurrentPlayer)) return true;

            return false;
        }

        public void ChangeCellsTextRemaind()
        {
            foreach (CellInfo cell in board)
            {
                if (cell.text == "X" || cell.text == "O")
                {
                    if (cell != null)
                    {
                        cell.movesRemaind -= 1;
                        if (cell.movesRemaind == 0)
                        {
                            cell.text = " ";
                        }
                    }
                }
            }
        }

        public void SwitchPlayer()
        { 
            BackColor = (CurrentPlayer == "X")? Color.FromArgb(192, 0, 0) : Color.FromArgb(0, 0, 192);
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
        }


        public void Reset() 
        {
            board = new CellInfo[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i,j] = new CellInfo();
                }
            }
            CurrentPlayer = "X";
            BackColor = Color.FromArgb(0, 0, 192);
        }

    }
}
