using GamesApp.Models;
using GamesApp.Views.GamePanels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

    }
}
