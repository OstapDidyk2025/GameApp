using GamesApp.Models;
using GamesApp.Views.GamePanels;

namespace GamesApp.Controllers
{
    internal class TicTacToeController : IGameController
    {
        private TicTacToeModel _model;
        private TicTacToePanel _view;
        public bool isComputer = false;
        public TicTacToeController(TicTacToePanel view, bool IsComputer)
        {
            this._view = view;
            _model = new TicTacToeModel();
            isComputer = IsComputer;
            _model.Reset();
        }

        public void HandleClick(int x, int y)
        {
            if (_model.MakeMove(x, y, out var color))
            {
                _view.UpdateLabel(x, y, _model.CurrentPlayer, color);
                if (_model.CheckWin())
                {
                    _view.ShowMessage($"Гравець {_model.CurrentPlayer} виграв!");
                    _model.Reset();
                    _view.ResetGrid();
                    return;
                }
                else if (_model.IsDraw())
                {
                    _view.ShowMessage("Нічия!");
                    _model.Reset();
                    _view.ResetGrid();
                    return;
                }
                _model.SwitchPlayer();
            }
            if (isComputer == true)
            {
                if (_model.ComputerMove(out int a, out int b, out Color botColor))
                {
                    _view.UpdateLabel(a, b, _model.CurrentPlayer, botColor);
                    if (_model.CheckWin())
                    {
                        _view.ShowMessage($"Комп'ютер {_model.CurrentPlayer} виграв!");
                        _model.Reset();
                        _view.ResetGrid();
                        return;
                    }
                    else if (_model.IsDraw())
                    {
                        _view.ShowMessage("Нічия!");
                        _model.Reset();
                        _view.ResetGrid();
                        return;
                    }
                    _model.SwitchPlayer();
                }
            }
        }
    }
}
