﻿using System;
using System.Windows.Forms;

namespace H2D_Minesweeper
{
    public partial class frmMain : Form
    {
        private Game game;

        public frmMain()
        {
            InitializeComponent();
            game = new Game(pnGame);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            game.NewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.NewGame();
        }

        public static void ShowGameOver()
        {
            MessageBox.Show("Game over!", "Minesweeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
