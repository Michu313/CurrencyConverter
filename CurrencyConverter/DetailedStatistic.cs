using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyConverter
{
    class DetailedStatistic
    {
        public static void ChangeCurrencyPrice(float[] tab, ref float[] tab2)
        {
            bool a = false;
            for (int i = tab.Length-1; i >= 0; i--)
            {
                if(a==true)
                {
                    tab2[i] = Helper.RoundFloat(tab[i] - tab[i + 1], 4);
                    
                }
                if (a==false)
                {
                    tab2[29] = 0;
                    a = true;
                } 
            }
        }

        public static float GratestValue(float[] tab)
        {
            float[] tab1 = new float[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                tab1[i] = tab[i];
            }
            Array.Sort(tab1);
            return tab1[29];
        }

        public static float SmallestValue(float[] tab)
        {
            float[] tab1 = new float[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                tab1[i] = tab[i];
            }
            Array.Sort(tab1);
            return tab1[0];
        }

        public static float AverageValue(float[] tab)
        {
            float a = 0; 
            for (int i = 0; i < tab.Length; i++)
            {
                a = a + tab[i];
            }
            return Helper.RoundFloat( a / tab.Length,4);
        }
        public static void FillTextBlock(ref TextBlock textBlock1, ref TextBlock textBlock2, ref TextBlock textBlock3, ref TextBlock textBlock4, ref TextBlock textBlock5, float[] Currency, float[] ChangeTab)
        {
            textBlock1.Text = "Największa wartość: " + DetailedStatistic.GratestValue(Currency) + "zł";
            textBlock2.Text = "Największy wzrost: " + DetailedStatistic.GratestValue(ChangeTab) + "zł";
            textBlock3.Text = "Najmniejsza wartość: " + DetailedStatistic.SmallestValue(Currency) + "zł";
            textBlock4.Text = "Największy spadek: " + DetailedStatistic.SmallestValue(ChangeTab) + "zł";
            textBlock5.Text = "Srednia cena: " + DetailedStatistic.AverageValue(Currency) + "zł";
        }
    }
}

