using GamesApp.Controllers;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Design;

namespace GamesApp.Views.GamePanels
{
    public partial class SudokuView : Form, IGameView
    {
        private SudokuController _controller;
        private Label[,] _labels = new Label[9, 9];
        private Button[] _buttons = new Button[10];
        private Button _btnStart = new Button();
        private Label _labelOfMistakes = new Label();
        private Label _timerLabel = new Label();

        public SudokuView()
        {
            InitializeComponent();
            _controller = new SudokuController(this);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.BackColor = Color.Gainsboro;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label lbl = new Label();
                    lbl.Size = new System.Drawing.Size(80, 80);
                    lbl.Location = new System.Drawing.Point(80 * i + 20 + DistanceCalc(i), 80 * j + 20 + DistanceCalc(j));
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
                btn.Size = new System.Drawing.Size(70, 70);
                btn.Location = new System.Drawing.Point(800 + (i/5 * 70), 70 * i + 100 - (i/5 * 350));
                btn.Font = new System.Drawing.Font("Arial", 30);
                if (i == 0)
                {
                    btn.Text = " ";
                }
                else
                {
                    btn.Text = i.ToString();
                }
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.BackColor = Color.AntiqueWhite;
                int x = i;
                btn.Click += (sender, e) => _controller.ButtonClick(x);
                _buttons[i] = btn;
                this.Controls.Add(btn);

            }

            _btnStart = new Button();
            _btnStart.Size = new System.Drawing.Size(140, 50);
            _btnStart.Location = new System.Drawing.Point(800, 710);
            _btnStart.Font = new System.Drawing.Font("Arial", 10);
            _btnStart.Text = "Start";
            _btnStart.BackColor = Color.Goldenrod;
            _btnStart.TextAlign = ContentAlignment.MiddleCenter;
            _btnStart.Click += (sender, e) => _controller.StartButtonClick();
            this.Controls.Add(_btnStart);

            _labelOfMistakes = new Label();
            _labelOfMistakes.Size = new System.Drawing.Size(140, 50);
            _labelOfMistakes.Location = new System.Drawing.Point(800, 650);
            _labelOfMistakes.Font = new System.Drawing.Font("Arial", 10);
            _labelOfMistakes.Text = $"Mistakes:{Environment.NewLine} 0 / 5";
            _labelOfMistakes.BackColor = Color.AntiqueWhite;
            _labelOfMistakes.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( _labelOfMistakes );

            _timerLabel = new Label();
            _timerLabel.Size = new System.Drawing.Size(140, 50);
            _timerLabel.Location = new System.Drawing.Point(800, 590);
            _timerLabel.Font = new System.Drawing.Font("Arial", 10);
            _timerLabel.Text = "00:00";
            _timerLabel.BackColor = Color.AntiqueWhite;
            _timerLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(_timerLabel);

        }

        private int DistanceCalc(int x)
        {
            return x / 3 * 10;
        }

        public void HightlightCells(int numberOfButton)
        {
            foreach (Label lbl in _labels)
            {
                if (lbl.Text == numberOfButton.ToString() && lbl.BackColor == Color.LightGreen)
                {
                    lbl.BackColor = Color.Khaki;
                }
            }
        }

        public void DisHightlightCells()
        {
            foreach (Label lbl in _labels)
            {
                if (lbl.BackColor == Color.Khaki)
                {
                    lbl.BackColor = Color.LightGreen;
                }
            }
        }

        public void UpdateTimer(string time)
        {
            if (InvokeRequired)
                Invoke(() => _timerLabel.Text = time);
            else
                _timerLabel.Text = time;
        }

        public void UpdateLabel(int x, int y, string number, Color color)
        {
            if (number == "0")
            {
                _labels[x, y].Text = " ";
            }
            else
            {
                _labels[x, y].Text = number;
            }
            _labels[x, y].BackColor = color;
            if (color == Color.LightGreen)
            {
                _labels[x,y].Enabled = false;
            }
        }

        public void ShowNumberOfMistakes(int mistakes)
        { 
            _labelOfMistakes.Text = $"Mistakes:{Environment.NewLine}{mistakes} / 5";
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
                        _labels[i, j].BackColor = Color.LightGreen;
                    }
                }
            }
            ShowNumberOfMistakes(0);
        }

        public void ResetGrid()
        {
            foreach (Label lbl in _labels)
            { 
                lbl.Text = string.Empty;
                lbl.BackColor = Color.White;
                lbl.Enabled = true;
            }
        }

        public void UpgradeStartButton()
        {
            _btnStart.Text = "Restart";
        }
    }
}
