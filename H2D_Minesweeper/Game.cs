using H2D_Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace H2D_Minesweeper
{
    public class Game
    {
        private static int NumCol = 8;
        private static int NumRow = 8;

        private CellBlock[,] mainBoard = new CellBlock[8, 8];
        private Random rand = new Random();
        private Panel pnGame = new Panel();
        private Button btnNewGame = new Button();
        private Label lbMine = new Label();
        private static int MineNumber = 0;
        private int MineFlag = 0;
        private bool GameOver;
        private bool GameWin;
        private Dictionary<string, Label> dicLabel = new Dictionary<string, Label>();

        public Game(Panel panel, Button button, Label label, int numCol = 8, int numRow = 8, int numMine = 10)
        {
            pnGame = panel;
            btnNewGame = button;
            lbMine = label;
            NumCol = numCol;
            NumRow = numRow;
            MineNumber = numMine;
            mainBoard = new CellBlock[numCol, numRow];
        }

        public void NewGame()
        {
            MineFlag = 0;
            lbMine.Text = MineNumber.ToString();
            GameOver = false;
            GameWin = false;
            pnGame.Controls.Clear();
            dicLabel.Clear();
            CreatValueBoard();
            PaintBoardMask();
            btnNewGame.Image = Resources._new;
        }
        private void PaintBoardMask()
        {
            for (int i = 0; i < NumCol; i++)
            {
                for (int j = 0; j < NumRow; j++)
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
                    dicLabel.Add(i + "-" + j, label);
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameOver || GameWin)
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
                if (mainBoard[X, Y].NumMine == -1)
                {
                    label.BackColor = Color.Red;
                    GameOver = true;
                    btnNewGame.Image = Resources.lose;
                    ShowGameOver();
                    return;
                }
                ShowBlock(label, mainBoard[X, Y]);
                mainBoard[X, Y].BlockType = BlockType.Open;
            }
            else if (e.Button == MouseButtons.Right)
            {
                //gắn cờ
                if (MineFlag >= MineNumber)
                {
                    return;
                }
                //Nếu đã gắn cờ rồi
                if (mainBoard[X, Y].BlockType == BlockType.Flag)
                {
                    mainBoard[X, Y].BlockType = BlockType.None;
                    label.Image = Resources.cell;
                    MineFlag--;
                }
                else if (mainBoard[X, Y].BlockType == BlockType.None)
                {
                    mainBoard[X, Y].BlockType = BlockType.Flag;
                    label.Image = Resources.Untitled;
                    MineFlag++;
                }
                lbMine.Text = (MineNumber - MineFlag).ToString().PadLeft(3, '0');
            }
            else
            {
                return;
            }
            if (CheckFinish())
            {
                GameWin = true;
                btnNewGame.Image = Resources.win;
                ShowGameOver();
            }
        }

        private void ShowEmptyBlock(int x, int y)
        {
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (i >= 0 && i <= NumCol - 1 && j >= 0 && j <= NumRow - 1 && mainBoard[i, j].NumMine >= 0)
                    {
                        if (mainBoard[i, j].BlockType == BlockType.None)
                        {
                            if (dicLabel.ContainsKey(i + "-" + j))
                            {
                                ShowBlock(dicLabel[i + "-" + j], mainBoard[i, j]);
                            }
                        }
                    }
                }
            }
        }

        private bool CheckFinish()
        {
            for (int i = 0; i < NumCol; i++)
            {
                for (int j = 0; j < NumRow; j++)
                {
                    if (!dicLabel.ContainsKey(i + "-" + j))
                    {
                        continue;
                    }
                    var label = dicLabel[i + "-" + j];
                    if (label != null)
                    {
                        string[] loc = label.Tag.ToString().Split('-');
                        int X = int.Parse(loc[0]);
                        int Y = int.Parse(loc[1]);
                        if (mainBoard[X, Y].NumMine != -1 && mainBoard[X, Y].BlockType == BlockType.None)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void ShowBlock(Label label, CellBlock cellBlock)
        {
            label.Image = null;
            label.Text = cellBlock.NumMine == 0 ? "" : cellBlock.NumMine.ToString();
            string[] loc = label.Tag.ToString().Split('-');
            int X = int.Parse(loc[0]);
            int Y = int.Parse(loc[1]);
            cellBlock.BlockType = BlockType.Open;
            switch (cellBlock.NumMine)
            {
                case 0:
                    ShowEmptyBlock(X, Y);
                    break;
                case 1:
                    label.ForeColor = Color.Blue;
                    break;
                case 2:
                    label.ForeColor = Color.DarkGreen;
                    break;
                case 3:
                    label.ForeColor = Color.Red;
                    break;
                case 4:
                    label.ForeColor = Color.DarkBlue;
                    break;
                case 5:
                    label.ForeColor = Color.DarkRed;
                    break;
                case 6:
                    label.ForeColor = Color.BlueViolet;
                    break;
                case -1:
                    label.Text = "";
                    label.Image = Resources.clanbomber;
                    break;
            }
        }

        public void ShowGameOver()
        {
            for (int i = 0; i < NumCol; i++)
            {
                for (int j = 0; j < NumRow; j++)
                {
                    if (!dicLabel.ContainsKey(i + "-" + j))
                    {
                        continue;
                    }
                    var label = dicLabel[i + "-" + j];
                    if (label != null)
                    {
                        string[] loc = label.Tag.ToString().Split('-');
                        int X = int.Parse(loc[0]);
                        int Y = int.Parse(loc[1]);
                        if (mainBoard[X, Y].NumMine == -1)
                        {
                            ShowBlock(label, mainBoard[X, Y]);
                        }
                    }
                }
            }
        }

        private void CreatValueBoard()
        {
            for (int i = 0; i < NumCol; i++)
            {
                for (int j = 0; j < NumRow; j++)
                {
                    mainBoard[i, j] = new CellBlock { NumMine = 0, BlockType = BlockType.None };
                }
            }
            int numMine = 0;
            while (numMine < MineNumber)
            {
                int randX = rand.Next(0, NumCol - 1);
                int randY = rand.Next(0, NumRow - 1);
                if (mainBoard[randX, randY].NumMine != -1)
                {
                    mainBoard[randX, randY].NumMine = -1;
                    numMine++;
                }
            }
            for (int i = 0; i < NumCol; i++)
            {
                for (int j = 0; j < NumRow; j++)
                {
                    //Nếu ô đó có boom
                    if (mainBoard[i, j].NumMine == -1)
                    {
                        //Tất cả vị trí trừ vòng ngoài
                        if (i > 0 && j > 0 && i < NumCol - 1 && j < NumRow - 1)
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
                            if (j < NumRow - 1)
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
                        if (i == NumCol - 1 && j > 0)
                        {
                            if (j < NumRow - 1)
                            {
                                SetNumberNear(i - 1, j + 1);
                                SetNumberNear(i, j + 1);
                            }
                            //Bao gồm góc dưới bên phải
                            SetNumberNear(i - 1, j - 1);
                            SetNumberNear(i - 1, j);
                            if (j != NumRow - 1)
                            {
                                SetNumberNear(i, j - 1);
                            }
                        }
                        //Tất cả vị trí sát mép bên trái
                        if (i > 0 && j == 0)
                        {
                            if (i < NumCol - 1)
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
                        if (i > 0 && j == NumRow - 1)
                        {
                            if (i < NumCol - 1)
                            {
                                SetNumberNear(i + 1, j - 1);
                                SetNumberNear(i + 1, j);
                            }
                            if (i != NumCol - 1)
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
            if (mainBoard[i, j].NumMine != -1)
                mainBoard[i, j].NumMine++;
        }
    }
}
