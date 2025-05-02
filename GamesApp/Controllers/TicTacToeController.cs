using GamesApp.Models;
using GamesApp.Views.GamePanels;

namespace GamesApp.Controllers
{
    internal class TicTacToeController : IGameController
    {
        private TicTacToeModel model;
        private TicTacToePanel view;
        public bool isComputer = false;
        public TicTacToeController(TicTacToePanel view, bool IsComputer)
        {
            this.view = view;
            model = new TicTacToeModel();
            isComputer = IsComputer;
            model.Reset();
        }

        public void HandleClick(int x, int y)
        {
            if (model.MakeMove(x, y, out var color))
            {
                view.UpdateLabel(x, y, model.CurrentPlayer, color);
                if (model.CheckWin())
                {
                    view.ShowMessage($"Гравець {model.CurrentPlayer} виграв!");
                    model.Reset();
                    view.ResetGrid();
                    return;
                }
                else if (model.IsDraw())
                {
                    view.ShowMessage("Нічия!");
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
                    if (model.CheckWin())
                    {
                        view.ShowMessage($"Комп'ютер {model.CurrentPlayer} виграв!");
                        model.Reset();
                        view.ResetGrid();
                        return;
                    }
                    else if (model.IsDraw())
                    {
                        view.ShowMessage("Нічия!");
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
