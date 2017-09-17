using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class LifeGame
    {
        int X_Valid ;
        int Y_Valid ;
        public int X_Max;
        public int Y_Max;

        public void Initialyze33(int[] map)
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

        public void Initialyze55(int[] map)
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

        public LifeGame(int x, int y)
        {
            X_Valid = x;
            Y_Valid = y;
            X_Max = X_Valid + 2;
            Y_Max = Y_Valid + 2;
        }

        public int[] Calc(int[] map)
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
            return newMap;
        }

    }
}
