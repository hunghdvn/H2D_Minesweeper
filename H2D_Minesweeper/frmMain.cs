using System;
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

        private void mnuNewGane_Click(object sender, EventArgs e)
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
    }
}
