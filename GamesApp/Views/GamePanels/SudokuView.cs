using GamesApp.Controllers;
using System.Drawing.Design;

namespace GamesApp.Views.GamePanels
{
    public partial class SudokuView : Form, IGameView
    {
        private SudokuController _controller;
        private Label[,] _labels = new Label[9, 9];
        private Button[] _buttons = new Button[10];
        private Button _btnStart = new Button();

        public SudokuView()
        {
            InitializeComponent();
            _controller = new SudokuController(this);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(1000, 800);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label lbl = new Label();
                    lbl.Size = new System.Drawing.Size(80, 80);
                    lbl.Location = new System.Drawing.Point(80 * i + 50, 80 * j + 50);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.BackColor = Color.White;
                    lbl.Font = new System.Drawing.Font("Arial", 25);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    int x = i; int y = j;
                    lbl.Click += (sender, e) => _controller.LabelClick(x, y);
                    _labels[i, j] = lbl;
                    this.Controls.Add(lbl);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(50, 50);
                btn.Location = new System.Drawing.Point(850, 50 * i + 100);
                btn.Font = new System.Drawing.Font("Arial", 20);
                if (i == 0)
                {
                    btn.Text = " ";
                }
                else
                {
                    btn.Text = i.ToString();
                }
                btn.TextAlign = ContentAlignment.MiddleCenter;
                int x = i;
                btn.Click += (sender, e) => _controller.ButtonClick(x);
                _buttons[i] = btn;
                this.Controls.Add(btn);

            }

            _btnStart = new Button();
            _btnStart.Size = new System.Drawing.Size(100, 50);
            _btnStart.Location = new System.Drawing.Point(800, 700);
            _btnStart.Font = new System.Drawing.Font("Arial", 10);
            _btnStart.Text = "Start";
            _btnStart.TextAlign = ContentAlignment.MiddleCenter;
            _btnStart.Click += (sender, e) => _controller.StartButtonClick();
            this.Controls.Add(_btnStart);
        }

        public void UpdateLabel(int x, int y, string number, Color color)
        {
            _labels[x, y].Text = number;
            _labels[x, y].BackColor = color;
            if (color == Color.Aqua)
            {
                _labels[x,y].Enabled = false;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowLevel(int[,] board)
        {
            for (int i = 0; i < _labels.GetLength(0); i++)
            {
                for (int j = 0; j < _labels.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        _labels[i, j].Text = " ";
                    }
                    else 
                    {
                        _labels[i, j].Text = board[i, j].ToString();
                        _labels[i, j].Enabled = false;
                        _labels[i, j].BackColor = Color.Aqua;
                    }
                }
            }
        }

        public void ResetGrid()
        {
            foreach (Label lbl in _labels)
            { 
                lbl.Text = string.Empty;
                lbl.BackColor = Color.White;
            }
        }

        public void UpgradeStartButton()
        {
            _btnStart.Text = "Restart";
        }
    }
}
