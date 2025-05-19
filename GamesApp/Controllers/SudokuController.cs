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

            _model.sudokuTimer.Tick += TimerTick;
        }

        public void TimerTick(object sender, EventArgs e)
        {
            _view.UpdateTimer(_model.sudokuTimer.GetTime());  
        }

        public void StartButtonClick()
        { 
            _view.ResetGrid();
            _model.Reset();
            _model.GenerateGreed();
            _view.UpgradeStartButton();
            _view.ShowLevel(_model.GenerateLevel());
            _model.sudokuTimer.Start();
        }

        public void LabelClick(int x, int y)
        {
            if (_model.MakeMove(x, y, out Color color))
            {
                _view.UpdateLabel(x, y, Convert.ToString(_model.chosenNumber), color);
                _view.HightlightCells(_model.chosenNumber);
                _view.ShowNumberOfMistakes(_model.mistakes);
                if (_model.CheckLose())
                {
                    _model.sudokuTimer.Stop();
                    _view.ShowMessage("Ви програли...");
                    StartButtonClick();
                }
                if (_model.CheckWin())
                {
                    _model.sudokuTimer.Stop();
                    _view.ShowMessage($"Вітаю з перемогою!{Environment.NewLine}Рівень пройдено за: {_model.sudokuTimer.GetTime()}");
                }
            }
        }

        public void ButtonClick(int x) 
        {
            _view.DisHightlightCells();
            _model.SetNumber(x);
            _view.HightlightCells(x);
        }

    }
}
