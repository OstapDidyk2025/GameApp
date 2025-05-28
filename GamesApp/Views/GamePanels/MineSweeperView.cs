using GamesApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamesApp.Views.GamePanels
{
    public partial class MineSweeperView : Form, IGameView
    {
        private MineSweeperController _controller;
        private Label[,] _labels = new Label[9,9];
        private Button[] _buttons = new Button[2];

        public MineSweeperView()
        {
            InitializeComponent();
            _controller = new MineSweeperController(this);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.BackColor = Color.Gainsboro;
            this.Text = "Сапер";
        }

        public void UpdateLabel(int x, int y, string Status, Color color)
        { 
        
        }

        public void ShowMessage(string message)
        { }

        public void ResetGrid()
        { }


    }
}
