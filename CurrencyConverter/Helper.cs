using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyConverter
{
    public class Helper
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
        /// Select image
        /// </summary>
        /// <param name="tab">Tab currency</param>
        /// <param name="tab2">Tab image</param>
        public static void SelectImage( float[] tab, ref string[] tab2)
        {
            int tmp = (int)(tab[29]* 10000);
            for (int i = 29; i >= 0; i--)
            {
                int tmp1 = (int)(tab[i] * 10000);
                if (tmp1 == tmp)
                {
                    tab2[i] = "/Image/image2.png";
                    tmp = (int)(tab[i] * 10000);
                }
                if (tmp1 > tmp)
                {
                    tab2[i] = "/Image/image1.png";
                    tmp = (int)(tab[i] * 10000);
                }
                if (tmp1 < tmp)
                {
                    tab2[i] = "/Image/image3.png";
                    tmp = (int)(tab[i] * 10000);
                }
            }
        }

        public static void AddItemToComboBoxList(ref ComboBox comboBox, bool addPln)
        {
            string[] tab = Course.GetAllNameCurrent();
            if (addPln==true)
            {
            comboBox.Items.Add("PLN");
            }
            for (int i = 0; i < tab.Length; i++)
            {
                comboBox.Items.Add(tab[i]);
            }
        }
    }
}
