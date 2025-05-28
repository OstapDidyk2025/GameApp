using GamesApp.Controllers;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace GamesApp.Views.GamePanels
{
    public partial class TicTacToeNewVersionView : Form , IGameView
    {

        private TicTacToeNewVersionController _controller;
        private Label[,] _labels = new Label[3, 3];

        public TicTacToeNewVersionView(bool isComputer)
        {
            InitializeComponent();
            _controller = new TicTacToeNewVersionController(this, isComputer);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.BackColor = Color.Gainsboro;
            this.Text = "Терні Лапілі";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Label lbl = new Label();
                    lbl.Size = new System.Drawing.Size(200, 200);
                    lbl.Location = new System.Drawing.Point(i * 200, j * 200);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new System.Drawing.Font("Arial", 50);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    int x = i; int y = j;
                    lbl.Click += (sender, e) => _controller.HandleClick(x, y);
                    _labels[i, j] = lbl;
                    this.Controls.Add(lbl);
                }
            }
        }

        public void UpdateLabel(int x, int y, string text, Color color)
        {
            _labels[x, y].Text = text;
            _labels[x, y].Enabled = false;
            _labels[x, y].BackColor = color;
        }

        public void ReenableLabel(CellInfo[,] cells)
        { 
            for(int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j].movesRemaind == 0)
                    {
                        _labels[i, j].Text = "";
                        _labels[i, j].Enabled = true;
                        _labels[i, j].BackColor = Color.White;
                    }
                }
            }
        }


        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ResetGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    _labels[i,j].Text = "";
                    _labels[i,j].Enabled = true;
                    _labels[i,j].BackColor = Color.White;
                }
            }
        }
    }
}
