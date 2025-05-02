using GamesApp.Controllers;

namespace GamesApp.Views.GamePanels
{
    partial class TicTacToePanel : Form, IGameView
    {
        private TicTacToeController controller;
        private Label[,] labels = new Label[3, 3];

        public TicTacToePanel(bool isComputer)
        {
            InitializeComponent();
            controller = new TicTacToeController(this, isComputer);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
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
                    lbl.Click += (sender, e) => controller.HandleClick(x, y);
                    labels[i, j] = lbl;
                    this.Controls.Add(lbl);
                }
            }
        }

        public void UpdateLabel(int x, int y, string text, Color color)
        {
            labels[x, y].BackColor = color;
            labels[x, y].Text = text;
            labels[x, y].Enabled = false;
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
                    labels[i, j].Text = " ";
                    labels[i, j].Enabled = true;
                    labels[i, j].BackColor = Color.White;
                }
        }

    }
}
