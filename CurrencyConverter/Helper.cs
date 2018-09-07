using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace CurrencyConverter
{
    public class Helper
    {
        public static float RoundFloat(float a, int q)
        {
            int w=1;
            for (int i = 0; i < q; i++)
            {
                w = w * 10;
            }
            int tmp = (int)(a*w);
            float b = tmp;
            b = b / w;
            return b;
        }

        public static float StringToFloat(string a)
        {
            float b = float.Parse(a , CultureInfo.InvariantCulture.NumberFormat);
            return b;
        }

        public static string FormatDate(string date)
        {
            int q = 0;
            string a1 = "", a2 = "", a3 = "";
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == '-')
                {
                    q++;
                    i++;
                }
                if (q == 0)
                {
                    a1 += date[i];
                }
                if (q == 1)
                {
                    a2 += date[i];
                }
                if (q == 2)
                {
                    a3 += date[i];
                }
            }
            return a3 + "-" + a2 + "-" + a1;
        }

        /// <summary>
        /// Select image
        /// </summary>
        /// <param name="tab">Tab currency</param>
        /// <param name="tab2">Tab image</param>
        public static void SelectImage(double[] tab, ref string[] tab2)
        {
            double tmp = tab[29];
            for (int i = 29; i >= 0; i--)
            {
                double tmp1 =tab[i];
                if (tmp1 == tmp)
                {
                    tab2[i] = "/Image/image2.png";
                    tmp = tab[i];
                }
                if (tmp1 > tmp)
                {
                    tab2[i] = "/Image/image1.png";
                    tmp = tab[i];
                }
                if (tmp1 < tmp)
                {
                    tab2[i] = "/Image/image3.png";
                    tmp = tab[i];
                }
            }
        }

        public static void AddItemToComboBoxList(ref ComboBox comboBox, bool addPln, bool mode)
        {
            string[] tab;
            if (mode==true)
            {
                tab = Course.GetAllNameCurrent();
            }
            else
            {
                tab = CourseOffline.GetAllNameCurrentOffline();
            }
            
            if (addPln==true)
            {
            comboBox.Items.Add("PLN");
            }
            for (int i = 0; i < tab.Length; i++)
            {
                comboBox.Items.Add(tab[i]);
            }
        }

        public static bool CheckTextBox(string a)
        {
            Regex regex = new Regex("^(-?)(0|([1-9][0-9]*))(\\.[0-9]+)?$");
            if (regex.IsMatch(a)==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckConnectInternet()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://api.nbp.pl"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public static string ReversDate()
        {
            string tmp = CourseOffline.GetDataCurrencyOffline();
            string tmp1 = tmp[0] +""+ tmp[1]+""+tmp[2]+""+tmp[3];
            string tmp2 = tmp[5] + "" + tmp[6];
            string tmp3 = tmp[8] + "" + tmp[9];
            return tmp3 + "-" + tmp2 + "-" + tmp1;
        }

    }
    
}
