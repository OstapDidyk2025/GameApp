using GamesApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamesApp.Views.GamePanels
{
    public partial class MineSweeperView : Form, IGameView
    {
        private MineSweeperController _controller;
        private Label[,] _labels = new Label[9,9];
        private Button[] _buttons = new Button[2];
        private Button _btnStart = new Button();
        private Label _timerLabel = new Label();

        public MineSweeperView()
        {
            InitializeComponent();
            _controller = new MineSweeperController(this);
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(1100, 900);
            this.BackColor = Color.Gainsboro;
            this.Text = "Сапер";
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Label lbl = new Label();
                    lbl.Size = new System.Drawing.Size(90, 90);
                    lbl.Location = new System.Drawing.Point(90 * i + 20, 90 * j + 20);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.BackColor = Color.LightGray;
                    lbl.Font = new System.Drawing.Font("Arial", 25);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    int x = i; int y = j;
                    lbl.Click += (sender, e) => _controller.LabelClick(x, y);
                    _labels[i, j] = lbl;
                    this.Controls.Add(lbl);
                }
            }

            for (int i = 0; i < _buttons.Length; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(80, 80);
                btn.Location = new System.Drawing.Point(880 + 80 * i, 200);
                btn.BackColor = Color.AntiqueWhite;
                int x = i;
                btn.Click += (sender, e) => _controller.ButtonClick(x);
                _buttons[i] = btn;
                this.Controls.Add(btn);
            }


            _buttons[0].BackgroundImage = Properties.Resources.flag;
            _buttons[0].BackgroundImageLayout = ImageLayout.Stretch;
            _buttons[1].BackgroundImage = Properties.Resources.tap;
            _buttons[1].BackgroundImageLayout = ImageLayout.Stretch;

            _btnStart = new Button();
            _btnStart.Size = new System.Drawing.Size(160, 80);
            _btnStart.Location = new System.Drawing.Point(880, 500);
            _btnStart.Font = new System.Drawing.Font("Arial", 20);
            _btnStart.Text = "Start";
            _btnStart.BackColor = Color.Goldenrod;
            _btnStart.TextAlign = ContentAlignment.MiddleCenter;
            _btnStart.Click += (sender, e) => _controller.StartButtonClick();
            this.Controls.Add(_btnStart);

            _timerLabel = new Label();
            _timerLabel.Size = new System.Drawing.Size(160, 80);
            _timerLabel.Location = new System.Drawing.Point(880, 300);
            _timerLabel.Font = new System.Drawing.Font("Arial", 20);
            _timerLabel.Text = "00:00";
            _timerLabel.BackColor = Color.AntiqueWhite;
            _timerLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(_timerLabel);

        }

        public void UpdateLabel(int x, int y, string Status, Color color)
        {

            Image image;
            Image resizedImage;

            string patern = @"^\d+$";

            Regex numberRegex = new Regex(patern);

            if (numberRegex.IsMatch(Status))
            {
                _labels[x, y].Image = null;
                _labels[x, y].BackColor = color;
                _labels[x, y].Text = Status;
            }
            else if (Status == "mine")
            {
                _labels[x, y].BackColor = color;
                image = Properties.Resources.mine2;
                resizedImage = new Bitmap(image, _labels[x, y].Size);
                _labels[x, y].Image = resizedImage;
            }
            else if (Status == "flag")
            {
                _labels[x, y].BackColor = color;
                image = Properties.Resources.flag;
                resizedImage = new Bitmap(image, _labels[x, y].Size);
                _labels[x, y].Image = resizedImage;
            }
            else if (Status == "safe") 
            {
                _labels[x, y].Image = null;
                _labels[x, y].BackColor = color;
            }

        }
        public void UpdateTimer(string time)
        {
            if (InvokeRequired)
                Invoke(() => _timerLabel.Text = time);
            else
                _timerLabel.Text = time;
        }


        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ResetGrid()
        {
            for (int i = 0; i < _labels.GetLength(0); i++)
            {
                for (int j = 0; j < _labels.GetLength(1); j++)
                {
                    _labels[i, j].BackColor = Color.Gray;
                    _labels[i, j].Text = String.Empty;
                    _labels[i, j].Image = null;
                }
            }

        }


    }
}
