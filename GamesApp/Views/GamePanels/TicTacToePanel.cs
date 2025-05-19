using GamesApp.Controllers;

namespace GamesApp.Views.GamePanels
{
    partial class TicTacToePanel : Form, IGameView
    {
        private TicTacToeController _controller;
        private Label[,] _labels = new Label[3, 3];

        public TicTacToePanel(bool isComputer)
        {
            InitializeComponent();
            _controller = new TicTacToeController(this, isComputer);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.BackColor = Color.Gainsboro;
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    Label lbl = new Label();
                    lbl.Size = new System.Drawing.Size(200, 200);
                    lbl.Location = new System.Drawing.Point(200 * i, 200 * j);
                    lbl.Font = new System.Drawing.Font("Arial", 50);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
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
            _labels[x, y].BackColor = color;
            _labels[x, y].Text = text;
            _labels[x, y].Enabled = false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        public void ResetGrid()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    _labels[i, j].Text = " ";
                    _labels[i, j].Enabled = true;
                    _labels[i, j].BackColor = Color.White;
                }
        }

    }
}
