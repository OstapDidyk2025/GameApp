using GamesApp.Controllers;

namespace GamesApp
{
    public partial class MainMenuView : Form
    {
        private MainController _controller;
        private RadioButton[] _radioButtons = new RadioButton[6];
        private Panel _panelGameMode;
        private Button _startButton;
        private Button[] _ruleButtons = new Button[4];
        public MainMenuView()
        {
            InitializeComponent();
            _controller = new MainController(this);
            _panelGameMode = new Panel();
            _startButton = new Button();
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.BackColor = Color.Gainsboro;
            this.Text = "Головне меню";
            string[] names = { "Terni Lapili", "TicTacToe", "Sudoku", "Mineswepper", "PVP", "Computer"};

            for (int i = 0; i < _radioButtons.Length; i++)
            {
                if (i < 4)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.AutoSize = true;
                    rbtn.Text = names[i];
                    rbtn.Font = new System.Drawing.Font("Arial", 15);
                    rbtn.Checked = false;
                    rbtn.Location = new System.Drawing.Point(145, 50 + (70 * i));
                    this.Controls.Add(rbtn);
                    _radioButtons[i] = rbtn;
                }
                else 
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.AutoSize = true;
                    rbtn.Text = names[i];
                    rbtn.Font = new System.Drawing.Font("Arial", 15);
                    rbtn.Checked = false;
                    rbtn.Location = new System.Drawing.Point(5, 70 * (i/5));
                    this.Controls.Add(rbtn);
                    _radioButtons[i] = rbtn;
                }

                _radioButtons[i].Click += (sender, e) => _controller.RadioButton_CheckedChange();
            }

            for (int i = 0; i < _ruleButtons.Length; i++ )
            { 
                Button button = new Button();
                button.Text = "?";
                button.Font = new System.Drawing.Font("Arial", 20);
                button.Location = new System.Drawing.Point(80, 45 + (70 * i));
                button.BackColor = Color.Goldenrod;
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Size = new System.Drawing.Size(40, 40);
                this.Controls.Add(button);
                int index = i;
                button.Click += (sender, e) => _controller.ShowRules(index);
            }

            _panelGameMode.Size = new System.Drawing.Size(200, 100);
            _panelGameMode.Location = new System.Drawing.Point(450, 50);
            _panelGameMode.Enabled = false;
            _panelGameMode.Controls.Add(_radioButtons[4]);
            _panelGameMode.Controls.Add(_radioButtons[5]);
            _panelGameMode.Visible = false;
            this.Controls.Add(_panelGameMode);

            _startButton.Location = new System.Drawing.Point(450, 250);
            _startButton.Enabled = false;
            _startButton.Font = new System.Drawing.Font("Arial", 15);
            _startButton.Text = "Start";
            _startButton.BackColor = Color.Goldenrod;
            _startButton.TextAlign = ContentAlignment.MiddleCenter;
            _startButton.Size = new System.Drawing.Size(150, 60);
            this.Controls.Add(_startButton);

            _startButton.Click += (sender, e) => _controller.HandleClik();
        }

        public void GenerateRuleForm(string name, string rules)
        {
            Form ruleFrom = new Form(); 
            ruleFrom.Size = new System.Drawing.Size(800, 650);
            ruleFrom.BackColor = Color.Gainsboro;
            ruleFrom.Text = name;

            TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(700, 500);
            textBox.ScrollBars = ScrollBars.Horizontal;
            textBox.Location = new System.Drawing.Point(50, 10);
            textBox.Font = new System.Drawing.Font("Arial", 15);
            textBox.Text = rules;
            textBox.ReadOnly = true;
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            ruleFrom.Controls.Add(textBox);





            ruleFrom.ShowDialog();
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
