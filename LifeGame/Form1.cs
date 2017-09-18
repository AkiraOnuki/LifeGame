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
        //メインフォームプログラムが開始したときに表示されるフォームクラスproguram.csファイルから呼ばれている

        //ライフゲームクラスの定義
        LifeGame lg;

        //メインフォームのコンストラクタ
        public Form1()
        {
            //ライフゲームクラスをマップサイズ50*50で作成
            lg = new LifeGame(50, 50);
            lg.Initialyze55();

            InitializeComponent();

        }

        //ストップボタンクリックイベント
        private void button1_Click(object sender, EventArgs e)
        {
            //ストップボタンを使えなくしている
            buttonStop.Enabled = false;
            //ストップボタンをゆうこうにしている
            buttonStart.Enabled = true;
            //タイマーを止める
            timer1.Enabled = false;
        }

        //スタートボタンクリックイベント
        private void button2_Click(object sender, EventArgs e)
        {
            //ストップボタンを有効にしている
            buttonStop.Enabled = true;
            //スタートボタンを無効にしている
            buttonStart.Enabled = false;
            //タイマーを起動
            timer1.Enabled = true;
        }

        //タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            //タイマーイベントが来たらマップ再計算
            lg.Calc();
            //イメージの再描画を指示
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //イメージの再描画、bitmapクラスでbitmap化
            e.Graphics.DrawImage(Image.FromStream(bitmap.ToBitmap(lg.Map, 50, 50)), new Rectangle(0, 0, 400, 400), new Rectangle(0, 0, 50, 50), GraphicsUnit.Pixel);
        }

        //イメージダブルクリックイベント
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //タイマーを起動
            timer1.Enabled = false;
            //フォームにクラス作成
            Form2 frm = new Form2();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //ダイアログがOKならパターンをコピー
                lg.Initialyze(frm.pattern, e.X / 8, e.Y / 8);
                //イメージの再描画を指示
                pictureBox1.Invalidate();

            }
            //タイマーを起動
            timer1.Enabled = true;
        }
    }
}
