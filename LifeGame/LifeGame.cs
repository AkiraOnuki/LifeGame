using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class LifeGame : Object
    {
        int X_Valid ;
        int Y_Valid ;
        int X_Max;
        int Y_Max;

        public int[] map;

        public LifeGame(int x, int y)
        {
            X_Valid = x;
            Y_Valid = y;
            X_Max = X_Valid + 2;
            Y_Max = Y_Valid + 2;
            map = new int[X_Max * Y_Max];
        }

        public void Initialyze(int[] pat, int x, int y)
        {
            --x;
            --y;
            int h = (int)Math.Sqrt(pat.GetLength(0));


            for (int hy = 0; hy < h; ++hy)
            {
                for (int hx = 0; hx < h; ++hx)
                {
                    int map_s = (y * X_Valid + x) + hy * X_Valid + hx;
                    int pat_s = hy * h + hx;
                    map[map_s] = pat[pat_s];

                }
            }
        }

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
                              + map[(y) * X_Max + (x - 1)] + map[(y) * X_Max + (x + 1)]
                              + map[(y + 1) * X_Max + (x - 1)] + map[(y + 1) * X_Max + (x)] + map[(y + 1) * X_Max + (x + 1)];
                        if (check == 1)
                        {
                            if (A <= 1 || A >= 4)
                            {
                                newMap[y * X_Max + x] = 0;
                            }
                            else
                            {
                                newMap[y * X_Max + x] = 1;
                            }
                        }
                        else
                        {
                            if (A == 3)
                            {
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
