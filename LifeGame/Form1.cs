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

            Initialyze2();
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

        public void Initialyze2()
        {
            for (int l = 0; l < X_Max * Y_Max; ++l)
            {
                map[l] = 0;
            }
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - X_Max - 2] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - X_Max - 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - X_Max] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - X_Max + 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - X_Max + 2] = 1;

            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - 2] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max - 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) - X_Max + 2] = 1;

            map[(Y_Max / 2 * X_Max + X_Max / 2) - 2] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) - 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2)    ] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + 2] = 1;

            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max - 2] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max - 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max    ] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + 2] = 1;

            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max - 2] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max - 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max    ] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max + 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max + 2] = 1;
            ViewShow();
        }

        public void Anarayze()
        {
            string str = textBox1.Text;
            for (int y = 0; y < Y_Valid; ++y)
            {
                for (int x = 0; x < X_Valid; ++x)
                {
                    bool check = str[X_Max * y + x] == '○';
                    map[X_Max + (X_Max * y + x + 1)] = check ? 0 : 1;
                }
            }
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            timer1.Enabled = true;
        }

        public void ViewShow()
        {
            string str = "";
            for (int y = 1; y < Y_Max - 1; ++y)
            {
                for (int x = 1; x < X_Max - 1; ++x)
                {
                    int check = map[y * X_Max + x];
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


            int[] newMap = new int[X_Max * Y_Max];

            for (int y = 0; y < Y_Max; ++y)
            {
                for (int x = 0; x < X_Max; ++x)
                {
                    if (x > 0 && y > 0 && x < X_Max - 1 && y < Y_Max - 1)
                    {
                        int check = map[y * X_Max + x];
                        int A = map[(y - 1) * X_Max + (x - 1)] + map[(y - 1) * X_Max + (x)] + map[(y - 1) * X_Max + (x + 1)]
                              + map[(y    ) * X_Max + (x - 1)]                              + map[(y    ) * X_Max + (x + 1)]
                              + map[(y + 1) * X_Max + (x - 1)] + map[(y + 1) * X_Max + (x)] + map[(y + 1) * X_Max + (x + 1)];
                        if (check == 1)
                        {
                            if (A <= 1 || A >= 4)
                            {
                                newMap[y * Y_Max + x] = 0;
                            }
                            else
                            {
                                newMap[y * Y_Max + x] = 1;
                            }
                        }
                        else
                        {
                            if (A == 3)
                            {
                                newMap[y * Y_Max + x] = 1;
                            }
                        }
                    }
                }
            }
            map = newMap;
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
            Initialyze2();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Anarayze();
        }
    }
}
