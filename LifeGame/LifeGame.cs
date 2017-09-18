using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    // LifeGameを計算するクラス
    public class LifeGame : Object
    {
        // mapの有効範囲
        int X_Valid ;
        int Y_Valid ;
        
        //対角のmapのコピーのため行を上下左右増やした
        int X_Max;
        int Y_Max;
        //コピーするサイズを含めて配列のサイズを定義
        private int[] map;
        public int[] Map
        {
            get
            {
                //マップから有効範囲だけを抜き出して返す
                int[] ret = new int[X_Valid * Y_Valid];

                for (int y = 1; y < Y_Max - 1; ++y)
                {
                    for (int x = 1; x < X_Max - 1; ++x)
                    {
                        int check = map[y * X_Max + x];
                        ret[(y - 1) * X_Valid + (x - 1)] = check;
                    }
                }

                return ret;
            }
        }
        //マップ位置の計算式　Y位置　＊　Xサイズ　＋　X位置
        //mapのサイズをもらってクラスコンストラクタを定義
        public LifeGame(int x, int y)
        {
            X_Valid = x;
            Y_Valid = y;
            X_Max = X_Valid + 2;
            Y_Max = Y_Valid + 2;
            map = new int[X_Max * Y_Max];
        }

        //xy位置にパターンをコピーする。パターンは正方形を想定する
        public void Initialyze(int[] pat, int x, int y)
        {
            --x;
            --y;
            int h = (int)Math.Sqrt(pat.GetLength(0));


            for (int hy = 0; hy < h; ++hy)
            {
                for (int hx = 0; hx < h; ++hx)
                {
                    int map_s = (y * X_Max + x) + hy * X_Max + hx;
                    int pat_s = hy * h + hx;
                    map[map_s] = pat[pat_s];

                }
            }
        }

        //3*3マスの初期パターンをマップの真ん中にコピーする
        public void Initialyze33()
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
        }

        //5*5マスの初期パターンをマップの真ん中にコピーする
        public void Initialyze55()
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
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + 1] = 1;
            map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + 2] = 1;

            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max - 2] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max - 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max    ] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max + 1] = 1;
            //map[(Y_Max / 2 * X_Max + X_Max / 2) + X_Max + X_Max + 2] = 1;
        }

        //マップをテキストパターンを変換する
        public override string ToString()
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
            return str;
        }

        //LifeGameの計算。新しいマップを作製する
        public void Calc()
        {
            //下有効パターンを上にコピー
            for (int xl = 1; xl < X_Max - 1; ++xl)
            {
                map[(Y_Max + 0) * 0 + xl] = map[(Y_Max - 2) * X_Max + xl];
            }
            //上有効パターンをしたにコピーする
            for (int xl = 1; xl < X_Max - 1; ++xl)
            {
                map[(Y_Max - 1) * X_Max + xl] = map[X_Max + xl];
            }
            //左有効パターンを右にコピーする
            for (int yl = 1; yl < Y_Max - 1; ++yl)
            {
                map[((X_Max - 1) * yl) + yl] = map[((X_Max - 1) * yl) + X_Max + yl - 2];
            }
            //右有効パターンを左にコピーする
            for (int yl = 1; yl < X_Max - 1; ++yl)
            {
                map[((X_Max - 1) * yl) + X_Max + yl - 1] = map[((X_Max) * yl) + 1];
            }
            //対角の有効パターンをコピーする
            map[0] = map[(Y_Max - 1) * X_Max - 2];
            map[X_Max - 1] = map[(Y_Max - 2) * X_Max + 1];
            map[(Y_Max - 1) * X_Max] = map[Y_Max * X_Max - 2];
            map[Y_Max * X_Max - 1] = map[X_Max + 1];

            //新規のマップ作製
            int[] newMap = new int[X_Max * Y_Max];

            for (int y = 0; y < Y_Max; ++y)
            {
                for (int x = 0; x < X_Max; ++x)
                {
                    if (x > 0 && y > 0 && x < X_Max - 1 && y < Y_Max - 1)
                    {
                        //現在のマップを調べる
                        int check = map[y * X_Max + x];
                        //調べた個所の周り8マスを合計している（lifeがあれば1、なければ0）
                        int A = map[(y - 1) * X_Max + (x - 1)] + map[(y - 1) * X_Max + (x)] + map[(y - 1) * X_Max + (x + 1)]
                              + map[(y) * X_Max + (x - 1)] + map[(y) * X_Max + (x + 1)]
                              + map[(y + 1) * X_Max + (x - 1)] + map[(y + 1) * X_Max + (x)] + map[(y + 1) * X_Max + (x + 1)];
                        if (check == 1)
                        {
                            //Lifeがあれば
                            if (A <= 1 || A >= 4)
                            {
                                //１以下または４以上の時死滅
                                newMap[y * X_Max + x] = 0;
                            }
                            else
                            {
                                //それ以外（2か3の時）誕生
                                newMap[y * X_Max + x] = 1;
                            }
                        }
                        else
                        {
                            //life  がなければ
                            if (A == 3)
                            {
                                //まわりのlifeがちょうど3の時誕生
                                newMap[y * X_Max + x] = 1;
                            }
                        }
                    }
                }
            }
            map = newMap;
        }

    }
}
