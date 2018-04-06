using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Helpes
    {
        public static float Round(float a)
        { 
            int tmp = (int)(a*100);
            float b = tmp;
            b = b / 100;
            return b;
        }

        public static float StringToFloat(string a)
        {
            float b = float.Parse(a , CultureInfo.InvariantCulture.NumberFormat);
            return b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab">Currency</param>
        /// <param name="tab2">ImageCurse</param>
        /// <param name="a"></param>
        public static void SelectImage( float[,] tab, ref string[,] tab2, int a)
        {
            
            int tmp = (int)(tab[29,a]* 10000);
            for (int i = 29; i >= 0; i--)
            {
                int tmp1 = (int)(tab[i,a] * 10000);
                if (tmp1 == tmp)
                {
                    tab2[i,a] = "/Image/image2.png";
                    tmp = (int)(tab[i,a] * 10000);
                }
                if (tmp1 > tmp)
                {
                    tab2[i,a] = "/Image/image1.png";
                    tmp = (int)(tab[i,a] * 10000);
                }
                if (tmp1 < tmp)
                {
                    tab2[i,a] = "/Image/image3.png";
                    tmp = (int)(tab[i,a] * 10000);
                }
            }
            
        }
    }
}
