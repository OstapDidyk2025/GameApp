
using GamesApp.Views.GamePanels;

namespace GamesApp.Models
{
    internal class MainModel
    {
        private TicTacToePanel _ticTacToePanel;

        private TicTacToeNewVersionView _ticTacToeNewVersionView;

        private SudokuView _sudokuView;

        private MineSweeperView _mineSweeperView;

        public void StartGame(int gameNumber, bool isPlayer)
        {
            switch (gameNumber)
            {
                case 0:
                    _ticTacToeNewVersionView = new TicTacToeNewVersionView(isPlayer);
                    _ticTacToeNewVersionView.ShowDialog();
                    break;
                case 1:
                    _ticTacToePanel = new TicTacToePanel(isPlayer);
                    _ticTacToePanel.ShowDialog();
                    break;
                case 2:
                    _sudokuView = new SudokuView();
                    _sudokuView.ShowDialog();
                    break;
                case 3:
                    _mineSweeperView = new MineSweeperView();
                    _mineSweeperView.ShowDialog();
                    break;
            }
        }

        public (string, string)  GetRulesFor(int ruleIndex)
        {
            string[] names = { "Terni Lapili", "TicTacToe", "Sudoku", "Minesweeper"};
            string[] fileNames = {"TicTacToe2.txt", "TicTacToe.txt", "Sudoku.txt", "Minesweeper.txt"};

            string rules = string.Empty;

            try
            {
                StreamReader reader = new StreamReader(fileNames[ruleIndex]);
                rules = reader.ReadToEnd();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Вітаю, ви бляха щось поламали :) {Environment.NewLine} {ex}");
            }

            return ((ruleIndex >= 0 && ruleIndex < names.Length) ? names[ruleIndex] : "Правила не знайдено.", rules);
        }

    }
}
