using GamesApp.Controllers;

namespace GamesApp
{
    public partial class MainMenuView : Form
    {
        private MainController controller;
        private RadioButton[] radioButtons = new RadioButton[6];
        private Panel panelGameMode;
        private Button startButton;
        public MainMenuView()
        {
            InitializeComponent();
            controller = new MainController(this);
            panelGameMode = new Panel();
            startButton = new Button();
            InitailizeGrid();
        }

        public void InitailizeGrid()
        {
            RadioButton ticNevVersion = new RadioButton();
            ticNevVersion.Text = "TicTacToe3chips";
            ticNevVersion.Checked = false;
            ticNevVersion.Location = new System.Drawing.Point(100, 50);
            this.Controls.Add(ticNevVersion);
            radioButtons[0] = ticNevVersion;

            RadioButton ticTcToe = new RadioButton();
            ticTcToe.Text = "TicTacToe";
            ticTcToe.Checked = false;
            ticTcToe.Location = new System.Drawing.Point(100, 100);
            this.Controls.Add(ticTcToe);
            radioButtons[1] = ticTcToe;

            RadioButton sudoku = new RadioButton();
            sudoku.Text = "Sudoku";
            sudoku.Checked = false;
            sudoku.Location = new System.Drawing.Point(100, 150);
            this.Controls.Add(sudoku);
            radioButtons[2] = sudoku;

            RadioButton mineswepper = new RadioButton();
            mineswepper.Text = "Mineswepper";
            mineswepper.Checked = false;
            mineswepper.Location = new System.Drawing.Point(100, 200);
            this.Controls.Add(mineswepper);
            radioButtons[3] = mineswepper;

            RadioButton pvpMode = new RadioButton();
            pvpMode.Text = "PVP";
            pvpMode.Checked = false;
            pvpMode.Location = new System.Drawing.Point(5, 0);
            radioButtons[4] = pvpMode;

            RadioButton pvcMode = new RadioButton();
            pvcMode.Text = "Computer";
            pvcMode.Checked = false;
            pvcMode.Location = new System.Drawing.Point(5, 50);
            radioButtons[5] = pvcMode;

            panelGameMode.Size = new System.Drawing.Size(100, 70);
            panelGameMode.Location = new System.Drawing.Point(300, 50);
            panelGameMode.Enabled = false;
            panelGameMode.Controls.Add(pvcMode);
            panelGameMode.Controls.Add(pvpMode);
            this.Controls.Add(panelGameMode);

            startButton.Location = new System.Drawing.Point(100, 250);
            startButton.Enabled = false;
            startButton.Text = "Start";
            startButton.TextAlign = ContentAlignment.MiddleCenter;
            startButton.Size = new System.Drawing.Size(100, 40);
            this.Controls.Add(startButton);

            startButton.Click += (sender, e) => controller.HandleClik();

            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i].Click += (sender, e) => controller.RadioButton_CheckedChange();
            }
        }

        public (int, bool) GameChosenChecked()
        {
            int gameNumber = 0;
            bool isComputer = false;

            if (radioButtons[0].Checked == true || radioButtons[1].Checked == true)
            {
                panelGameMode.Enabled = true;
                if (radioButtons[4].Checked == true || radioButtons[5].Checked == true)
                {
                    startButton.Enabled = true;
                    if (radioButtons[4].Checked == true)
                    {
                        isComputer = false;
                    }
                    else if (radioButtons[5].Checked == true)
                    {
                        isComputer = true;
                    }
                }
                else
                {
                    startButton.Enabled = false;
                }
            }
            else if (radioButtons[2].Checked == true || radioButtons[3].Checked == true)
            {
                panelGameMode.Enabled = false;
                radioButtons[4].Checked = false;
                radioButtons[5].Checked = false;
                isComputer = false;
                startButton.Enabled = true;

            }

            for (int i = 0; i < radioButtons.Length - 2; i++)
            {
                if (radioButtons[i].Checked == true)
                {
                    gameNumber = i;
                }
            }

            return (gameNumber, isComputer);
        }
    }
}
