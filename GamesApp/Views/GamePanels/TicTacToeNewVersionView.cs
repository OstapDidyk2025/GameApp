using GamesApp.Controllers;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace GamesApp.Views.GamePanels
{
    public partial class TicTacToeNewVersionView : Form , IGameView
    {

        private TicTacToeNewVersionController controller;
        private Label[,] labels = new Label[3, 3];

        public TicTacToeNewVersionView(bool isComputer)
        {
            InitializeComponent();
            controller = new TicTacToeNewVersionController(this, isComputer);
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
                    lbl.Location = new System.Drawing.Point(i * 200, j * 200);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new System.Drawing.Font("Arial", 50);
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
            labels[x, y].Text = text;
            labels[x, y].Enabled = false;
            labels[x, y].BackColor = color;
        }

        public void ReenableLabel(CellInfo[,] cells)
        { 
            for(int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j].movesRemaind == 0)
                    {
                        labels[i, j].Text = "";
                        labels[i, j].Enabled = true;
                        labels[i, j].BackColor = Color.White;
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
                    labels[i,j].Text = "";
                    labels[i,j].Enabled = true;
                    labels[i,j].BackColor = Color.White;
                }
            }
        }
    }
}
