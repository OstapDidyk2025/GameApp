using GamesApp.Models;
using GamesApp.Views.GamePanels;

namespace GamesApp.Controllers
{
    internal class SudokuController
    {
        private SudokuModel _model;
        private SudokuView _view;

        public SudokuController(SudokuView view)
        { 
            this._view = view;    
            _model = new SudokuModel();
        }

        public void StartButtonClick()
        { 
            _view.ResetGrid();
            _model.Reset();
            _model.GenerateGreed();
            _view.UpgradeStartButton();
            _view.ShowLevel(_model.GenerateLevel());
        }

        public void LabelClick(int x, int y)
        {
            if (_model.MakeMove(x, y, out Color color))
            {
                _view.UpdateLabel(x, y, _model.chosenNumber, color);
                if (_model.CheckWin())
                {
                    _view.ShowMessage("Вітаю з перемогою!");
                }

            }
        }

        public void ButtonClick(int x) 
        {
            _model.SetNumber(x);
        }

    }
}
