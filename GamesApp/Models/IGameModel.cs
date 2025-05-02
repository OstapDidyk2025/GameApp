using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Models
{
    internal interface IGameModel
    {
        abstract bool MakeMove(int x, int y, out Color color);
        abstract bool CheckWin();
        abstract void Reset();
    }
}
