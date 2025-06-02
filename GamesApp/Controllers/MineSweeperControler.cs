using GamesApp.Models;
using GamesApp.Views.GamePanels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GamesApp.Controllers
{
    internal class MineSweeperController : IGameController
    {
        private MinesweeperModel _model;
        private MineSweeperView _view;

        public MineSweeperController(MineSweeperView view)
        { 
            _model = new MinesweeperModel();
            _view = view;

            _model.mineSweeperTimer.Tick += TimerTick;
        }

        public void TimerTick(object sender, EventArgs e)
        {
            _view.UpdateTimer(_model.mineSweeperTimer.GetTime());
        }

        public void ButtonClick(int i) 
        { 
            _model.SetStatus(i);
        }

        public void StartButtonClick()
        {
            _view.ResetGrid();
            _model.Reset();
            _model.GenerateLevel();
            _model.mineSweeperTimer.Start();
        }

        public void LabelClick(int x, int y)
        { 
            if (_model.MakeMove(x, y, out Color color))
            {
                _view.UpdateLabel(x, y, _model.cellStatus, Color.White);
                if (_model.CheckLose(x, y))
                {
                    _model.mineSweeperTimer.Stop();
                    _view.ShowMessage("Ви підірвались..");
                }

                var openedCells = _model.GetOpenedCells();

                foreach (var (i, j, status) in openedCells)
                {
                    _view.UpdateLabel(i, j, status, Color.White);
                }
                if (_model.CheckWin())
                {
                    _model.mineSweeperTimer.Stop();
                    _view.ShowMessage($"Ви знайшли всі міни!!!{Environment.NewLine}Рівень пройдено за: {_model.mineSweeperTimer.GetTime()}");
                }
            }
        }
    }
}
