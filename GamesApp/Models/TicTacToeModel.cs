
namespace GamesApp.Models
{
    internal class TicTacToeModel : IGameModel, IpvcMode
    {
        private string[,] _board = new string[3, 3];
        public string CurrentPlayer { get; private set; } = "X";
        public Color BoardColor { get; private set; } = Color.Blue;

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
            color = BoardColor;
            if (_board[x, y] != " ") return false;
            _board[x, y] = CurrentPlayer;
            return true;
        }

        public bool ComputerMove(out int a, out int b, out Color botColor)
        {
            string opponent = (CurrentPlayer == "X") ? "O" : "X";
            bool CheckMove = false;
            a = 0; b = 0;

            foreach (var line in winningLines)
            {
                var texts = line.Select(pos => _board[pos.Item1, pos.Item2]).ToArray();
                if (texts.Count(t => t == CurrentPlayer) == 2 && texts.Count(t => t == " ") == 1)
                {
                    var empty = line.First(pos => _board[pos.Item1, pos.Item2] == " ");
                    botColor = BoardColor;
                    CheckMove = MakeMove(a = empty.Item1, b = empty.Item2, out var color);
                    return CheckMove;
                }
            }

            foreach (var line in winningLines)
            {
                var texts = line.Select(pos => _board[pos.Item1, pos.Item2]).ToArray();
                if (texts.Count(t => t == opponent) == 2 && texts.Count(t => t == " ") == 1)
                {
                    var empty = line.First(pos => _board[pos.Item1, pos.Item2] == " ");
                    botColor = BoardColor;
                    CheckMove = MakeMove(a = empty.Item1, b = empty.Item2, out var color);
                    return CheckMove;
                }
            }

            if (_board[1, 1] == " ")
            {
                a = 1; b = 1;
                botColor = BoardColor;
                CheckMove = MakeMove(a, b, out var color);
                return CheckMove;
            }

            foreach (var (i, j) in new[] { (0, 0), (0, 2), (2, 0), (2, 2) })
            {
                if (_board[i, j] == " ")
                {
                    a = i; b = j;
                    botColor = BoardColor;
                    CheckMove = MakeMove(a, b, out var color);
                    return CheckMove;
                }
            }

            foreach (var (i, j) in new[] { (1, 0), (0, 1), (2, 1), (1, 2) })
            {
                if (_board[i, j] == " ")
                {
                    a = i; b = j;
                    botColor = BoardColor;
                    CheckMove = MakeMove(i, j, out var color);
                    return CheckMove;
                }
            }

            botColor = BoardColor;
            return false;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
                if (_board[i, 0] == CurrentPlayer && _board[i, 1] == CurrentPlayer && _board[i, 2] == CurrentPlayer) return true;

            for (int j = 0; j < 3; j++)
                if (_board[0, j] == CurrentPlayer && _board[1, j] == CurrentPlayer && _board[2, j] == CurrentPlayer) return true;

            if (_board[0, 0] == CurrentPlayer && _board[1, 1] == CurrentPlayer && _board[2, 2] == CurrentPlayer) return true;
            if (_board[0, 2] == CurrentPlayer && _board[1, 1] == CurrentPlayer && _board[2, 0] == CurrentPlayer) return true;

            return false;
        }

        public bool IsDraw()
        {
            foreach (var cell in _board)
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
            _board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = " ";
                }
            }
            CurrentPlayer = "X";
            BoardColor = Color.FromArgb(0, 0, 192);
        }
    }
}
