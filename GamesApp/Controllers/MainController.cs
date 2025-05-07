using GamesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Controllers
{
    internal class MainController
    {
        private MainMenuView _view;
        private MainModel _model;
        private bool _isComputer;
        private int _gameChosen;

        public MainController(MainMenuView view)
        { 
            this._view = view;
            _model = new MainModel();
            _isComputer = true;
            _gameChosen = 0;
        }

        public void RadioButton_CheckedChange()
        {
            var result = _view.GameChosenChecked();
            _gameChosen = result.Item1;
            _isComputer = result.Item2;
        }

        public void HandleClik()
        {
            _model.StartGame(_gameChosen, _isComputer);
        }
    }
}
