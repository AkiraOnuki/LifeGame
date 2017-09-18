using System;using System.Collections.Generic;
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
            lg.Initialyze55();

            InitializeComponent();

            //ViewShow(lg);

        }

        public void ViewShow(LifeGame lg)
        {
            pictureBox1.Image = Image.FromStream(bitmap.ToBitmap(lg.map, 50, 50));
            //textBox1.Text = lg.ToString();
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
            lg.Calc();
            //ViewShow(lg);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image.FromStream(bitmap.ToBitmap(lg.map, 50, 50)), new Rectangle(0, 0, 400, 400), new Rectangle(0, 0, 50, 50), GraphicsUnit.Pixel);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            Form2 frm = new Form2();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lg.Initialyze(frm.pattern, e.X / 8, e.Y / 8);
                pictureBox1.Invalidate();

            }
        }
    }
}
