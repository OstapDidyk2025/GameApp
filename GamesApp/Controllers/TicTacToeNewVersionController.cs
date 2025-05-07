

using GamesApp.Models;
using GamesApp.Views.GamePanels;

namespace GamesApp.Controllers
{
    internal class TicTacToeNewVersionController : IGameController
    {
        private TicTacToeNewVersionModel _model;
        private TicTacToeNewVersionView _view;
        private bool _isComputer = false;
        public TicTacToeNewVersionController(TicTacToeNewVersionView view, bool IsComputer)
        {
            this._view = view;
            _model = new TicTacToeNewVersionModel();
            _isComputer = IsComputer;
            _model.Reset();
        }

        public void HandleClick(int x, int y)
        {
            if (_model.MakeMove(x, y, out var color))
            {
                _view.UpdateLabel(x, y, _model.CurrentPlayer, color);
                _view.ReenableLabel(_model.board);
                _model.ChangeCellsTextRemaind();
                if (_model.CheckWin())
                {
                    _view.ShowMessage($"Гравець {_model.CurrentPlayer} виграв!");
                    _model.Reset();
                    _view.ResetGrid();
                    return;
                }
                _model.SwitchPlayer();

                if (_isComputer == true)
                {
                    if (_model.ComputerMove(out int a, out int b, out Color botColor))
                    {
                        _view.UpdateLabel(a, b, _model.CurrentPlayer, botColor);
                        _view.ReenableLabel(_model.board);
                        _model.ChangeCellsTextRemaind();
                        if (_model.CheckWin())
                        {
                            _view.ShowMessage($"Комп'ютер виграв!");
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
}
