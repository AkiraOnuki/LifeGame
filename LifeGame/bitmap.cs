using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    public class bitmap
    {
        public static Stream ToBitmap(int[] map, int x, int y)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);

            int a = (x * 3) % 4;
            
            bw.Write('B');
            bw.Write('M');
            bw.Write((int)14 + 12 + (x * 3 + a) * y);
            bw.Write((short)0);
            bw.Write((short)0);
            bw.Write((int)14 + 12);

            bw.Write((int)12);
            bw.Write((short)x);
            bw.Write((short)y);
            bw.Write((short)1);
            bw.Write((short)24);

            for (int higet = y - 1; higet >= 0; --higet)
            {
                for (int width = 0; width < x; ++width)
                {
                    if (map[higet * x + width] == 1)
                    {
                        bw.Write((byte)255);
                        bw.Write((byte)255);
                        bw.Write((byte)255);
                    }
                    else
                    {
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                    }
                }
                if (a > 0)
                {
                    for (int l = 0; l < a; ++l)
                    {
                        bw.Write((byte)0);
                    }
                }
            }
            return ms;
        }
    }
}
