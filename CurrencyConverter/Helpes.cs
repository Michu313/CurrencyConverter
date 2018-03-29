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
    }
}
