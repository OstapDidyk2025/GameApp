
using GamesApp.Views.GamePanels;

namespace GamesApp.Models
{
    internal class MainModel
    {
        private TicTacToePanel _ticTacToePanel;

        private TicTacToeNewVersionView _ticTacToeNewVersionView;

        private SudokuView _sudokuView;

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
            }
        }
    }
}
