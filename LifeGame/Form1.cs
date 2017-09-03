using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class Form1 : Form
    {

        private int[] map;
        static int X_Valid = 100;
        static int Y_Valid = 100;
        static int X_Max = X_Valid + 2;
        static int Y_Max = Y_Valid + 2;


        public Form1()
        {
            map = new int[X_Max * Y_Max];

            InitializeComponent();

            Initialyze();
        }

        public void Initialyze()
        {
            for (int l = 0; l < X_Max * Y_Max; ++l)
            {
                map[l] = 0;
            }
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) - 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max - 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + 1] = 1;
            ViewShow();
        }

        public void ViewShow()
        {
            string str = "";
            for (int y = 1; y < Y_Max - 1; ++y)
            {
                for (int x = 1; x < X_Max - 1; ++x)
                {
                    int check = map[y * Y_Max + x];
                    if (check == 1)
                    {
                        str += "●";
                    }
                    else
                    {
                        str += "○";
                    }
                }
                str += "\r\n";
            }
            //string str = "";
            //for (int y = 0; y < Y_Max; ++y)
            //{
            //    for (int x = 0; x < X_Max; ++x)
            //    {
            //        int check = map[y * Y_Max + x];

            //        switch (check)
            //        {
            //            case 0:
            //                str += "０";
            //                break;
            //            case 1:
            //                str += "１";
            //                break;
            //            case 2:
            //                str += "２";
            //                break;
            //            case 3:
            //                str += "３";
            //                break;
            //            case 4:
            //                str += "４";
            //                break;
            //            case 5:
            //                str += "５";
            //                break;
            //            case 6:
            //                str += "６";
            //                break;
            //            case 7:
            //                str += "７";
            //                break;
            //            case 8:
            //                str += "８";
            //                break;
            //            case 9:
            //                str += "９";
            //                break;
            //            case 10:
            //                str += "Ａ";
            //                break;
            //            case 11:
            //                str += "Ｂ";
            //                break;
            //            case 12:
            //                str += "Ｃ";
            //                break;
            //            case 13:
            //                str += "Ｄ";
            //                break;
            //            case 14:
            //                str += "Ｅ";
            //                break;
            //            case 15:
            //                str += "Ｆ";
            //                break;
            //            case 16:
            //                str += "Ｇ";
            //                break;
            //            default:
            //                str += "●";
            //                break;
            //        }
            //    }
            //    str += "\r\n";
            //}
            textBox1.Text = str;
        }

        public void Calc()
        {
            for (int xl = 1; xl < X_Max - 1; ++xl)
            {
                map[(Y_Max + 0) * 0 + xl] = map[(Y_Max - 2) * X_Max + xl];
            }

            for (int xl = 1; xl < X_Max - 1; ++xl)
            {
                map[(Y_Max - 1) * X_Max + xl] = map[X_Max + xl];
            }

            for (int yl = 1; yl < Y_Max - 1; ++yl)
            {
                map[((X_Max - 1) * yl) + yl] = map[((X_Max - 1) * yl) + X_Max + yl - 2];
            }

            for (int yl = 1; yl < X_Max - 1; ++yl)
            {
                map[((X_Max - 1) * yl) + X_Max + yl - 1] = map[((X_Max) * yl) + 1];
            }

            map[0] = map[(Y_Max - 1) * X_Max - 2];
            map[X_Max - 1] = map[(Y_Max - 2) * X_Max + 1];
            map[(Y_Max - 1) * X_Max] = map[Y_Max * X_Max - 2];
            map[Y_Max * X_Max - 1] = map[X_Max + 1];

            for (int y = 0; y < Y_Max; ++y)
            {
                for (int x = 0; x < X_Max; ++x)
                {
                    if (x > 0 && y > 0 && x < X_Max - 1 && y < Y_Max - 1)
                    {
                        int check = map[y * Y_Max + x];
                        int A = map[(y - 1) * X_Max + (x - 1)] + map[(y - 1) * X_Max + (x)] + map[(y - 1) * X_Max + (x + 1)]
                              + map[(y) * X_Max + (x - 1)] + map[(y) * X_Max + (x + 1)]
                              + map[(y + 1) * X_Max + (x - 1)] + map[(y + 1) * X_Max + (x)] + map[(y + 1) * X_Max + (x + 1)];
                        if (check == 1)
                        {
                            if (A <= 1 || A >= 4)
                            {
                                map[y * Y_Max + x] = 0;
                            }
                        }
                        else
                        {
                            if (A == 3)
                            {
                                map[y * Y_Max + x] = 1;
                            }
                        }
                    }
                }
            }
            ViewShow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Calc();
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            Initialyze();
        }
    }
}
