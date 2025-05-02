
using GamesApp.Views.GamePanels;

namespace GamesApp.Models
{
    internal class MainModel
    {
        TicTacToePanel ticTacToePanel;

        TicTacToeNewVersionView ticTacToeNewVersionView;

        SudokuView sudokuView;

        public void StartGame(int gameNumber, bool isPlayer)
        {
            switch (gameNumber)
            {
                case 0:
                    ticTacToeNewVersionView = new TicTacToeNewVersionView(isPlayer);
                    ticTacToeNewVersionView.ShowDialog();
                    break;
                case 1:
                    ticTacToePanel = new TicTacToePanel(isPlayer);
                    ticTacToePanel.ShowDialog();
                    break;
                case 2:
                    sudokuView = new SudokuView();
                    sudokuView.ShowDialog();
                    break;
            }
        }
    }
}
