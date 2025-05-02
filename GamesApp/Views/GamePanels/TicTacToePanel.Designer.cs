
namespace GamesApp.Views.GamePanels
{
    partial class TicTacToePanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameView
            // 
            this.Name = "GameView";
            this.Text = "Хрестики-Нолики";
            this.ResumeLayout(false);
        }

    }
}

