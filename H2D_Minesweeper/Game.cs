using H2D_Minesweeper.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace H2D_Minesweeper
{
    public class Game
    {
        private int[,] mainBoard = new int[10, 10];
        private Random rand = new Random();
        private Panel pnGame = new Panel();
        private int MineNumber = 0;
        private bool GameOver;

        public Game(Panel panel)
        {
            pnGame = panel;
        }

        public void NewGame()
        {
            GameOver = false;
            pnGame.Controls.Clear();
            CreatValueBoard();
            PaintBoardMask();
        }
        private void PaintBoardMask()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var point = new Point(i * 30, j * 30);
                    var font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    var label = new Label();
                    label.Width = 30;
                    label.Height = 30;
                    label.AutoSize = false;
                    label.Font = font;
                    label.Location = point;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Image = Resources.cell;
                    label.Tag = i + "-" + j;
                    label.MouseClick += Label_MouseClick;
                    pnGame.Controls.Add(label);
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameOver)
            {
                return;
            }
            var label = sender as Label;
            string[] loc = label.Tag.ToString().Split('-');
            int X = int.Parse(loc[0]);
            int Y = int.Parse(loc[1]);
            if (e.Button == MouseButtons.Left)
            {
                //Mở ô
                //Nếu mở phải mìn
                if (mainBoard[X, Y] == -1)
                {
                    label.BackColor = Color.Red;
                    GameOver = true;
                    ShowGameOver();
                    return;
                }
                //Nếu kích vào ô trắng
                if (mainBoard[X, Y] == 0)
                {

                }
                ShowBlock(label, mainBoard[X, Y]);
            }
            else if (e.Button == MouseButtons.Right)
            {
                //gắn cờ
                label.Image = Resources.Untitled;
            }
            else
            {
                return;
            }
            CheckFinish();
        }

        private void CheckFinish()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (var item in pnGame.Controls)
                    {
                        var label = item as Label;
                        string[] loc = label.Tag.ToString().Split('-');
                        int X = int.Parse(loc[0]);
                        int Y = int.Parse(loc[1]);
                        if (mainBoard[X, Y] == -1 && label.Image != Resources.Untitled)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private static void ShowBlock(Label label, int v)
        {
            label.Image = null;
            label.Text = v == 0 ? "" : v.ToString();
            switch (label.Text)
            {
                case "1":
                    label.ForeColor = Color.Blue;
                    break;
                case "2":
                    label.ForeColor = Color.DarkGreen;
                    break;
                case "3":
                    label.ForeColor = Color.Red;
                    break;
                case "4":
                    label.ForeColor = Color.DarkBlue;
                    break;
                case "5":
                    label.ForeColor = Color.DarkRed;
                    break;
                case "-1":
                    label.Text = "";
                    label.Image = Resources.clanbomber;
                    break;
            }
        }

        public void ShowGameOver()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (var item in pnGame.Controls)
                    {
                        var label = item as Label;
                        string[] loc = label.Tag.ToString().Split('-');
                        int X = int.Parse(loc[0]);
                        int Y = int.Parse(loc[1]);
                        if (mainBoard[X, Y] == -1)
                        {
                            ShowBlock(label, mainBoard[X, Y]);
                        }
                    }
                }
            }
        }

        public void ShowAll()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (var item in pnGame.Controls)
                    {
                        var label = item as Label;
                        string[] loc = label.Tag.ToString().Split('-');
                        int X = int.Parse(loc[0]);
                        int Y = int.Parse(loc[1]);
                        ShowBlock(label, mainBoard[X, Y]);
                    }
                }
            }
        }

        private void CreatValueBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mainBoard[i, j] = 0;
                }
            }
            MineNumber = 0;
            mainBoard[0, 0] = -1;
            MineNumber++;
            mainBoard[0, 9] = -1;
            MineNumber++;
            mainBoard[9, 0] = -1;
            MineNumber++;
            mainBoard[9, 9] = -1;
            MineNumber++;
            while (MineNumber < 10)
            {
                int randX = rand.Next(0, 9);
                int randY = rand.Next(0, 9);
                if (mainBoard[randX, randY] != -1)
                {
                    mainBoard[randX, randY] = -1;
                    MineNumber++;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Nếu ô đó có boom
                    if (mainBoard[i, j] == -1)
                    {
                        //Tất cả vị trí trừ vòng ngoài
                        if (i > 0 && j > 0 && i < 9 && j < 9)
                        {
                            SetNumberNear(i - 1, j - 1);
                            SetNumberNear(i, j - 1);
                            SetNumberNear(i + 1, j - 1);
                            SetNumberNear(i - 1, j);
                            SetNumberNear(i - 1, j + 1);
                            SetNumberNear(i, j + 1);
                            SetNumberNear(i + 1, j + 1);
                            SetNumberNear(i + 1, j);
                        }
                        //Tất cả vị trí sát mép trên
                        if (i == 0 && j > 0)
                        {
                            if (j < 9)
                            {
                                SetNumberNear(i, j + 1);
                                SetNumberNear(i + 1, j + 1);
                            }
                            //Bao gồm góc trên bên phải
                            SetNumberNear(i, j - 1);
                            SetNumberNear(i + 1, j - 1);
                            SetNumberNear(i + 1, j);
                        }
                        //Tất cả vị trí sát mép dưới
                        if (i == 9 && j > 0)
                        {
                            if (j < 9)
                            {
                                SetNumberNear(i - 1, j + 1);
                                SetNumberNear(i, j + 1);
                            }
                            //Bao gồm góc dưới bên phải
                            SetNumberNear(i - 1, j - 1);
                            SetNumberNear(i - 1, j);
                            if (j != 9)
                            {
                                SetNumberNear(i, j - 1);
                            }
                        }
                        //Tất cả vị trí sát mép bên trái
                        if (i > 0 && j == 0)
                        {
                            if (i < 9)
                            {
                                SetNumberNear(i + 1, j + 1);
                                SetNumberNear(i + 1, j);
                            }
                            //Bao gồm góc dưới bên trái
                            SetNumberNear(i - 1, j);
                            SetNumberNear(i - 1, j + 1);
                            SetNumberNear(i, j + 1);
                        }
                        //Tất cả vị trí sát mép bên phải trừ góc
                        if (i > 0 && j == 9)
                        {
                            if (i < 9)
                            {
                                SetNumberNear(i + 1, j - 1);
                                SetNumberNear(i + 1, j);
                            }
                            if (i != 9)
                            {
                                SetNumberNear(i - 1, j - 1);
                                SetNumberNear(i - 1, j);
                            }
                            SetNumberNear(i, j - 1);
                        }
                        //Góc trên cùng bên trái
                        if (i == 0 && j == 0)
                        {
                            SetNumberNear(i, j + 1);
                            SetNumberNear(i + 1, j + 1);
                            SetNumberNear(i + 1, j);
                        }
                    }
                }
            }
        }

        private void SetNumberNear(int i, int j)
        {
            if (mainBoard[i, j] != -1)
                mainBoard[i, j]++;
        }
    }
}
