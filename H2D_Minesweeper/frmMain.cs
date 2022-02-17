using System;
using System.Drawing;
using System.Windows.Forms;

namespace H2D_Minesweeper
{
    public partial class frmMain : Form
    {
        private Game game;

        public frmMain()
        {
            InitializeComponent();
            game = new Game(pnGame, btnNewGame, lbMine);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            game.NewGame();
        }

        private void mnuNewGame_Click(object sender, EventArgs e)
        {
            game.NewGame();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            game.NewGame();
        }

        private void mnuViewHelp_Click(object sender, EventArgs e)
        {
            var help = new frmHelp();
            help.ShowDialog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            var about = new frmAbout();
            about.ShowDialog();
        }

        private void mnuLevelEasy_Click(object sender, EventArgs e)
        {
            Width = 285;
            Height = 390;
            CenterToScreen();
            pnGame.Width = 240;
            pnGame.Height = 240;
            game = new Game(pnGame, btnNewGame, lbMine);
            game.NewGame();
        }

        private void mnuLevelNormal_Click(object sender, EventArgs e)
        {
            Width = 405;
            Height = 510;
            CenterToScreen();
            pnGame.Width = 360;
            pnGame.Height = 360;
            game = new Game(pnGame, btnNewGame, lbMine, 12, 12, 20);
            game.NewGame();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            btnNewGame.Location = new Point(Width / 2 - 16, 40);
        }

        private void mnuLevelHard_Click(object sender, EventArgs e)
        {
            Width = 495;
            Height = 600;
            CenterToScreen();
            pnGame.Width = 450;
            pnGame.Height = 450;
            game = new Game(pnGame, btnNewGame, lbMine, 15, 15, 30);
            game.NewGame();
        }

        private void mnuLevelVeryHard_Click(object sender, EventArgs e)
        {
            Width = 585;
            Height = 690;
            CenterToScreen();
            pnGame.Width = 540;
            pnGame.Height = 540;
            game = new Game(pnGame, btnNewGame, lbMine, 18, 18, 40);
            game.NewGame();
        }

        private void mnuLevelExtremeHard_Click(object sender, EventArgs e)
        {
            Width = 585;
            Height = 690;
            CenterToScreen();
            pnGame.Width = 540;
            pnGame.Height = 540;
            game = new Game(pnGame, btnNewGame, lbMine, 18, 18, 60);
            game.NewGame();
        }
    }
}
