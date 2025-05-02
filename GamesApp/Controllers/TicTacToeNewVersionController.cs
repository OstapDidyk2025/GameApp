

using GamesApp.Models;
using GamesApp.Views.GamePanels;

namespace GamesApp.Controllers
{
    internal class TicTacToeNewVersionController : IGameController
    {
        private TicTacToeNewVersionModel model;
        private TicTacToeNewVersionView view;
        private bool isComputer = false;
        public TicTacToeNewVersionController(TicTacToeNewVersionView view, bool IsComputer)
        {
            this.view = view;
            model = new TicTacToeNewVersionModel();
            isComputer = IsComputer;
            model.Reset();
        }

        public void HandleClick(int x, int y)
        {
            if (model.MakeMove(x, y, out var color))
            {
                view.UpdateLabel(x, y, model.CurrentPlayer, color);
                view.ReenableLabel(model.board);
                model.ChangeCellsTextRemaind();
                if (model.CheckWin())
                {
                    view.ShowMessage($"Гравець {model.CurrentPlayer} виграв!");
                    model.Reset();
                    view.ResetGrid();
                    return;
                }
                model.SwitchPlayer();
            }
            if (isComputer == true)
            {
                if (model.ComputerMove(out int a, out int b, out Color botColor))
                {
                    view.UpdateLabel(a, b, model.CurrentPlayer, botColor);
                    view.ReenableLabel(model.board);
                    model.ChangeCellsTextRemaind();
                    if (model.CheckWin())
                    {
                        view.ShowMessage($"Гравець {model.CurrentPlayer} виграв!");
                        model.Reset();
                        view.ResetGrid();
                        return;
                    }
                    model.SwitchPlayer();
                }
            }
        }
    }
}
