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
        int[] map;
        LifeGame lg;

        public Form1()
        {
            lg = new LifeGame(50, 50);
            map = new int[52 * 52];
            lg.Initialyze55(map);


            InitializeComponent();

            ViewShow(lg, map);

        }

        public void ViewShow(LifeGame lg, int[] map)
        {
            string str = "";
            for (int y = 1; y < lg.Y_Max - 1; ++y)
            {
                for (int x = 1; x <lg. X_Max - 1; ++x)
                {
                    int check = map[y * lg.X_Max + x];
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
            map = lg.Calc(map);
            ViewShow(lg, map);
        }
    }
}
