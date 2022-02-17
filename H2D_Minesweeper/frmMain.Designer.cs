namespace H2D_Minesweeper
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnGame = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelHard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelVeryHard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelExtremeHard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMine = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnGame
            // 
            this.pnGame.Location = new System.Drawing.Point(14, 95);
            this.pnGame.Name = "pnGame";
            this.pnGame.Size = new System.Drawing.Size(240, 240);
            this.pnGame.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(269, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewGame,
            this.levelToolStripMenuItem,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuNewGame
            // 
            this.mnuNewGame.Name = "mnuNewGame";
            this.mnuNewGame.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuNewGame.Size = new System.Drawing.Size(180, 22);
            this.mnuNewGame.Text = "&New game";
            this.mnuNewGame.Click += new System.EventHandler(this.mnuNewGame_Click);
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLevelEasy,
            this.mnuLevelNormal,
            this.mnuLevelHard,
            this.mnuLevelVeryHard,
            this.mnuLevelExtremeHard});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.levelToolStripMenuItem.Text = "&Level";
            // 
            // mnuLevelEasy
            // 
            this.mnuLevelEasy.Name = "mnuLevelEasy";
            this.mnuLevelEasy.Size = new System.Drawing.Size(144, 22);
            this.mnuLevelEasy.Text = "Easy";
            this.mnuLevelEasy.Click += new System.EventHandler(this.mnuLevelEasy_Click);
            // 
            // mnuLevelNormal
            // 
            this.mnuLevelNormal.Name = "mnuLevelNormal";
            this.mnuLevelNormal.Size = new System.Drawing.Size(144, 22);
            this.mnuLevelNormal.Text = "Normal";
            this.mnuLevelNormal.Click += new System.EventHandler(this.mnuLevelNormal_Click);
            // 
            // mnuLevelHard
            // 
            this.mnuLevelHard.Name = "mnuLevelHard";
            this.mnuLevelHard.Size = new System.Drawing.Size(144, 22);
            this.mnuLevelHard.Text = "Hard";
            this.mnuLevelHard.Click += new System.EventHandler(this.mnuLevelHard_Click);
            // 
            // mnuLevelVeryHard
            // 
            this.mnuLevelVeryHard.Name = "mnuLevelVeryHard";
            this.mnuLevelVeryHard.Size = new System.Drawing.Size(144, 22);
            this.mnuLevelVeryHard.Text = "Very hard";
            this.mnuLevelVeryHard.Click += new System.EventHandler(this.mnuLevelVeryHard_Click);
            // 
            // mnuLevelExtremeHard
            // 
            this.mnuLevelExtremeHard.Name = "mnuLevelExtremeHard";
            this.mnuLevelExtremeHard.Size = new System.Drawing.Size(144, 22);
            this.mnuLevelExtremeHard.Text = "Extreme hard";
            this.mnuLevelExtremeHard.Click += new System.EventHandler(this.mnuLevelExtremeHard_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewHelp,
            this.mnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuViewHelp
            // 
            this.mnuViewHelp.Name = "mnuViewHelp";
            this.mnuViewHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mnuViewHelp.Size = new System.Drawing.Size(173, 22);
            this.mnuViewHelp.Text = "&View Help";
            this.mnuViewHelp.Click += new System.EventHandler(this.mnuViewHelp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.mnuAbout.Size = new System.Drawing.Size(173, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // lbMine
            // 
            this.lbMine.BackColor = System.Drawing.Color.Black;
            this.lbMine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMine.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMine.ForeColor = System.Drawing.Color.Red;
            this.lbMine.Location = new System.Drawing.Point(26, 38);
            this.lbMine.Name = "lbMine";
            this.lbMine.Size = new System.Drawing.Size(56, 37);
            this.lbMine.TabIndex = 3;
            this.lbMine.Text = "010";
            this.lbMine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNewGame
            // 
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Image = global::H2D_Minesweeper.Properties.Resources._new;
            this.btnNewGame.Location = new System.Drawing.Point(119, 40);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(33, 33);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 351);
            this.Controls.Add(this.lbMine);
            this.Controls.Add(this.pnGame);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel pnGame;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewGame;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.Label lbMine;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelEasy;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelNormal;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelHard;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelVeryHard;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelExtremeHard;
    }
}

