using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Views
{
    internal interface IGameView
    {
        abstract void InitializeGrid();
        abstract void UpdateLabel(int x, int y, string text, Color color);
        abstract void ShowMessage(string message);
        abstract void ResetGrid();
    }
}
