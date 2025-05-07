using GamesApp.Controllers;

namespace GamesApp
{
    public partial class MainMenuView : Form
    {
        private MainController _controller;
        private RadioButton[] _radioButtons = new RadioButton[6];
        private Panel _panelGameMode;
        private Button _startButton;
        public MainMenuView()
        {
            InitializeComponent();
            _controller = new MainController(this);
            _panelGameMode = new Panel();
            _startButton = new Button();
            InitailizeGrid();
        }

        public void InitailizeGrid()
        {
            RadioButton ticNevVersion = new RadioButton();
            ticNevVersion.Text = "TicTacToe3chips";
            ticNevVersion.Checked = false;
            ticNevVersion.Location = new System.Drawing.Point(100, 50);
            this.Controls.Add(ticNevVersion);
            _radioButtons[0] = ticNevVersion;

            RadioButton ticTcToe = new RadioButton();
            ticTcToe.Text = "TicTacToe";
            ticTcToe.Checked = false;
            ticTcToe.Location = new System.Drawing.Point(100, 100);
            this.Controls.Add(ticTcToe);
            _radioButtons[1] = ticTcToe;

            RadioButton sudoku = new RadioButton();
            sudoku.Text = "Sudoku";
            sudoku.Checked = false;
            sudoku.Location = new System.Drawing.Point(100, 150);
            this.Controls.Add(sudoku);
            _radioButtons[2] = sudoku;

            RadioButton mineswepper = new RadioButton();
            mineswepper.Text = "Mineswepper";
            mineswepper.Checked = false;
            mineswepper.Location = new System.Drawing.Point(100, 200);
            this.Controls.Add(mineswepper);
            _radioButtons[3] = mineswepper;

            RadioButton pvpMode = new RadioButton();
            pvpMode.Text = "PVP";
            pvpMode.Checked = false;
            pvpMode.Location = new System.Drawing.Point(5, 0);
            _radioButtons[4] = pvpMode;

            RadioButton pvcMode = new RadioButton();
            pvcMode.Text = "Computer";
            pvcMode.Checked = false;
            pvcMode.Location = new System.Drawing.Point(5, 50);
            _radioButtons[5] = pvcMode;

            _panelGameMode.Size = new System.Drawing.Size(100, 70);
            _panelGameMode.Location = new System.Drawing.Point(300, 50);
            _panelGameMode.Enabled = false;
            _panelGameMode.Controls.Add(pvcMode);
            _panelGameMode.Controls.Add(pvpMode);
            _panelGameMode.Visible = false;
            this.Controls.Add(_panelGameMode);

            _startButton.Location = new System.Drawing.Point(100, 250);
            _startButton.Enabled = false;
            _startButton.Text = "Start";
            _startButton.TextAlign = ContentAlignment.MiddleCenter;
            _startButton.Size = new System.Drawing.Size(100, 40);
            this.Controls.Add(_startButton);

            _startButton.Click += (sender, e) => _controller.HandleClik();

            for (int i = 0; i < _radioButtons.Length; i++)
            {
                _radioButtons[i].Click += (sender, e) => _controller.RadioButton_CheckedChange();
            }
        }

        public (int, bool) GameChosenChecked()
        {
            int gameNumber = 0;
            bool isComputer = false;

            if (_radioButtons[0].Checked == true || _radioButtons[1].Checked == true)
            {
                _panelGameMode.Enabled = true;
                _panelGameMode.Visible = true;
                if (_radioButtons[4].Checked == true || _radioButtons[5].Checked == true)
                {
                    _startButton.Enabled = true;
                    if (_radioButtons[4].Checked == true)
                    {
                        isComputer = false;
                    }
                    else if (_radioButtons[5].Checked == true)
                    {
                        isComputer = true;
                    }
                }
                else
                {
                    _startButton.Enabled = false;
                }
            }
            else if (_radioButtons[2].Checked == true || _radioButtons[3].Checked == true)
            {
                _panelGameMode.Enabled = false;
                _panelGameMode.Visible = false;
                _radioButtons[4].Checked = false;
                _radioButtons[5].Checked = false;
                isComputer = false;
                _startButton.Enabled = true;

            }

            for (int i = 0; i < _radioButtons.Length - 2; i++)
            {
                if (_radioButtons[i].Checked == true)
                {
                    gameNumber = i;
                }
            }

            return (gameNumber, isComputer);
        }
    }
}
