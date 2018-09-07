using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConverter
{
    class CourseOffline
    {
        private static List<CurrencyXml> GetListCourseOffline()
        {
            XDocument xml = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "") + "\\OfflineCourseCurrent\\OfflineMode.xml");

            var tmp = from Rate in xml.Descendants("Rate")
                      select new
                      {
                          currency = Rate.Element("Currency").Value,
                          code = Rate.Element("Code").Value,
                          mid = Rate.Element("Mid").Value
                      };
            List<CurrencyXml> listCurrency = new List<CurrencyXml>();
            foreach (var item in tmp)
            {
                listCurrency.Add(new CurrencyXml(item.currency, item.code, item.mid));
            }
            return listCurrency;
        }

        public static float GetValueCurrenc(string currency)
        {
            List<CurrencyXml> list = GetListCourseOffline();
            CurrencyXml foundCurrency = list.Find(x => x.Code.Equals(currency));
            float tmp = Helper.StringToFloat(foundCurrency.Mid);
            return tmp;
        }

        public static string GetDataCurrencyOffline()
        {
            XDocument xml = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "") + "\\OfflineCourseCurrent\\OfflineMode.xml");
            string a = xml.Root.Element("EffectiveDate").Value;
            return a;
        }

        private static int GetAmountCurrency()
        {
            List<CurrencyXml> list = GetListCourseOffline();
            int tmp = 0;
            foreach (var item in list)
            {
                tmp++;
            }
            return tmp;
        }

        public static string[] GetAllNameCurrentOffline()
        {
            List<CurrencyXml> list = GetListCourseOffline();
            string[] tab = new string[GetAmountCurrency()];
            int i = 0;
            foreach (var item in list)
            {
                tab[i] = item.Code;
                i++;
            }
            return tab;
        }
    }
}
