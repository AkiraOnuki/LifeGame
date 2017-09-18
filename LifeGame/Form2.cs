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
    public partial class Form2 : Form
    {
        //編集したパターンを返すプロパティ
        public int[] pattern
        {
            get
            {
                //ボタンのテキストを調べパターンを作製
                int[] ret = new int[25];

                ret[0] =  button1_1.Text == "●" ? 1 : 0;
                ret[1] =  button1_2.Text == "●" ? 1 : 0;
                ret[2] =  button1_3.Text == "●" ? 1 : 0;
                ret[3] =  button1_4.Text == "●" ? 1 : 0;
                ret[4] =  button1_5.Text == "●" ? 1 : 0;
                ret[5] =  button2_1.Text == "●" ? 1 : 0;
                ret[6] =  button2_2.Text == "●" ? 1 : 0;
                ret[7] =  button2_3.Text == "●" ? 1 : 0;
                ret[8] =  button2_4.Text == "●" ? 1 : 0;
                ret[9] =  button2_5.Text == "●" ? 1 : 0;
                ret[10] = button3_1.Text == "●" ? 1 : 0;
                ret[11] = button3_2.Text == "●" ? 1 : 0;
                ret[12] = button3_3.Text == "●" ? 1 : 0;
                ret[13] = button3_4.Text == "●" ? 1 : 0;
                ret[14] = button3_5.Text == "●" ? 1 : 0;
                ret[15] = button4_1.Text == "●" ? 1 : 0;
                ret[16] = button4_2.Text == "●" ? 1 : 0;
                ret[17] = button4_3.Text == "●" ? 1 : 0;
                ret[18] = button4_4.Text == "●" ? 1 : 0;
                ret[19] = button4_5.Text == "●" ? 1 : 0;
                ret[20] = button5_1.Text == "●" ? 1 : 0;
                ret[21] = button5_2.Text == "●" ? 1 : 0;
                ret[22] = button5_3.Text == "●" ? 1 : 0;
                ret[23] = button5_4.Text == "●" ? 1 : 0;
                ret[24] = button5_5.Text == "●" ? 1 : 0;

                return ret;
            }
        }

        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ボタンがクリックされたらテキストを変える
            Button btn = sender as Button;
            if (btn.Text == "●")
                btn.Text = "○";
            else
                btn.Text = "●";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //ダイアログリザルトをOKにする
            DialogResult = DialogResult.OK;
        }
    }
}
