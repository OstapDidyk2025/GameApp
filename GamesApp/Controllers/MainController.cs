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
        private MainMenuView view;
        private MainModel model;
        private bool isComputer;
        private int gameChosen;

        public MainController(MainMenuView view)
        { 
            this.view = view;
            model = new MainModel();
            isComputer = true;
            gameChosen = 0;
        }

        public void RadioButton_CheckedChange()
        {
            var result = view.GameChosenChecked();
            gameChosen = result.Item1;
            isComputer = result.Item2;
        }

        public void HandleClik()
        {
            model.StartGame(gameChosen, isComputer);
        }
    }
}
