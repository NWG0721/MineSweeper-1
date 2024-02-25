using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MineSweeper
{

    public partial class GameForm : Form
    {

        int[,] TilesInfo = {
          //  a                          b                       c
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        Random Rand = new Random();

        public GameForm()
        {
            InitializeComponent();
        }

        private void btnSetting_MouseHover(object sender, EventArgs e)
        {
            btnSetting.ForeColor = Color.Red;
        }

        private void btnSetting_MouseLeave(object sender, EventArgs e)
        {
            btnSetting.ForeColor = Color.Gray;
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            generator();

        }
        private void generator()
        {
            int a, b, c, d, e, f, g, h,result = 9;
            //         18 x 13 btn

            int Randnum = Rand.Next(69, 85);
            int TileColl = Rand.Next(0, 12);
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    TilesInfo[i, j] = Rand.Next(0, 7);
                    if (TilesInfo[i, j]==0)
                    {
                        TilesInfo[i, j] = 10;
                    }
                    //txtConsole.Text += $"TileInfo[{i},{j}]= {TilesInfo[i, j].ToString()}\t";
                }

            }
            //txtConsole.Text += $"\t    | End of Validation |";
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (TilesInfo[i, j] != 10)
                    {

                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                e = TilesInfo[i, j + 1];

                                g = TilesInfo[i + 1, j];

                                h = TilesInfo[i + 1, j + 1];

                                result=  bomb_Counter(e, g, h);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j > 0 && j< 17)
                            {
                                d = TilesInfo[i, j - 1];

                                e = TilesInfo[i, j + 1];

                                f = TilesInfo[i + 1, j - 1];

                                g = TilesInfo[i + 1, j];

                                h = TilesInfo[i + 1, j + 1];

                                result = bomb_Counter(d,e,f,g,h);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j == 17)
                            {
                                d = TilesInfo[i, j - 1];

                                f = TilesInfo[i + 1, j - 1];

                                g = TilesInfo[i + 1, j];

                                result = bomb_Counter(d, f, g);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                        }


                        if (i > 0 && i < 12)
                        {
                            if (j == 0)
                            {
                                b = TilesInfo[i - 1, j];

                                c = TilesInfo[i - 1, j + 1];

                                e = TilesInfo[i, j + 1];

                                g = TilesInfo[i + 1, j];

                                h = TilesInfo[i + 1, j + 1];

                                result = bomb_Counter(b,c,e,g,h);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j > 0 && j < 17)
                            {
                                a = TilesInfo[i - 1, j - 1];

                                b = TilesInfo[i - 1, j];

                                c = TilesInfo[i - 1, j + 1];

                                d = TilesInfo[i, j - 1];

                                e = TilesInfo[i, j + 1];

                                f = TilesInfo[i + 1, j - 1];

                                g = TilesInfo[i + 1, j];

                                h = TilesInfo[i + 1, j + 1];

                                result = bomb_Counter(a,b,c,d,e,f,g,h);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j == 17)
                            {
                                a = TilesInfo[i - 1, j - 1];

                                b = TilesInfo[i - 1, j];

                                d = TilesInfo[i, j - 1];

                                f = TilesInfo[i + 1, j - 1];

                                g = TilesInfo[i + 1, j];

                                result = bomb_Counter(a, b, d,f, g);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                        }

                        if (i == 12)
                        {
                            if (j == 0)
                            {
                                b = TilesInfo[i - 1, j];

                                c = TilesInfo[i - 1, j + 1];

                                e = TilesInfo[i, j + 1];

                                result = bomb_Counter(b, c, e);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j > 0 && j < 17)
                            {
                                a = TilesInfo[i - 1, j - 1];

                                b = TilesInfo[i - 1, j];

                                c = TilesInfo[i - 1, j + 1];

                                d = TilesInfo[i, j - 1];

                                e = TilesInfo[i, j + 1];

                                result = bomb_Counter(a,b,c,d,e);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                            if (j == 17)
                            {
                                a = TilesInfo[i - 1, j - 1];

                                b = TilesInfo[i - 1, j];

                                d = TilesInfo[i, j - 1];

                                result = bomb_Counter(a, b, d);
                                //txtConsole.Text += $"Result = {result}\t";
                            }
                        }
                        //txtConsole.Text += $"\t    |End of result|\t";
                        TilesInfo[i, j] = result;
                        //txtConsole.Text += $"\t|LastRes = {result}|\t";
                    }
                }
            }
            //txtConsole.Text += $"\n    \t| End of results |\t";
            int k=0, l=0;
            foreach (Button btn in panel1.Controls)
            {
                btn.BackColor = Color.Gainsboro;
                btn.ForeColor = Color.Black;
            }
            foreach (Button btn in panel1.Controls)
            {
                btn.Text = TilesInfo[k, l].ToString();
                if (btn.Text == "10")
                {
                    btn.BackColor = Color.Black;
                }
                if (btn.Text == "1")
                {
                    btn.ForeColor = Color.Blue;
                }
                if (btn.Text == "2")
                {
                    btn.ForeColor = Color.Green;
                }
                if (btn.Text == "3")
                {
                    btn.ForeColor = Color.Tomato;
                }
                if (btn.Text == "4")
                {
                    btn.ForeColor = Color.Red;
                }
                if (btn.Text == "5")
                {
                    btn.ForeColor = Color.DarkBlue;
                }
                if (btn.Text == "6")
                {
                    btn.ForeColor = Color.Purple;
                }
                if (btn.Text == "7")
                {
                    btn.ForeColor = Color.Magenta;
                }
                if (btn.Text == "8")
                {
                    btn.ForeColor = Color.Cyan;
                }
                if (btn.Text == "9")
                {
                    btn.ForeColor = Color.Gainsboro;
                }
                //btn.Text = k.ToString();
                //txtConsole.Text += $"TileInfo[{k},{l}]= {TilesInfo[k, l].ToString()}\t";
                l++;
                if (l == 18)
                {
                    l = 0;
                    k++;
                }
                if (k == 13)
                {
                    k = 0;
                    break;
                }
            }
        }
        private void btnPrimery_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private int bomb_Counter(int a, int b, int c)
        {
            int result = 0;
            if (a ==10)
            {
                result++;
            }
            if (b == 10)
            {
                result++;
            }
            if (c == 10)
            {
                result++;
            }
            if (result == 0)
            {
                return 9;
            }
            else
            {
                return result;
            }
        }
        private int bomb_Counter(int a, int b, int c, int d, int e)
        {
            int result = 0;
            if (a == 10)
            {
                result++;
            }
            if (b == 10)
            {
                result++;
            }
            if (c == 10)
            {
                result++;
            }
            if (d == 10)
            {
                result++;
            }
            if (e == 10)
            {
                result++;
            }
            if (result == 0)
            {
                return 9;
            }
            else
            {
                return result;
            }
        }
        private int bomb_Counter(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int result = 0;
            if (a == 10)
            {
                result++;
            }
            if (b == 10)
            {
                result++;
            }
            if (c == 10)
            {
                result++;
            }
            if (d == 10)
            {
                result++;
            }
            if (e == 10)
            {
                result++;
            }
            if (f == 10)
            {
                result++;
            }
            if (g == 10)
            {
                result++;
            }
            if (h == 10)
            {
                result++;
            }
            if (result == 0)
            {
                return 9;
            }
            else
            {
                return result;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generator();
        }
    }
}
/*
 
                                 a = TilesInfo[i - 1, j - 1];

                                b = TilesInfo[i - 1, j];

                                c = TilesInfo[i - 1, j + 1];

                                d = TilesInfo[i, j - 1];

                                e = TilesInfo[i, j + 1];

                                f = TilesInfo[i + 1, j - 1];

                                g = TilesInfo[i + 1, j];

                                h = TilesInfo[i + 1, j + 1];
 
 */