using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace CurrencyConverter
{
    class Course
    {
        public Course() { }
        /// <summary>
        /// get aktually course currency
        /// </summary>
        /// <param name="currently">short name of the currency</param>
        /// <returns></returns>
        public static string GetCourse(string currently)
        {
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            foreach (XmlNode item in xd.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    XmlElement w = (XmlElement)pp.GetElementsByTagName("Code")[0];
                    if (w.InnerText == currently)
                    {
                        return Convert.ToString(pp.GetElementsByTagName("Mid")[0].InnerText);
                    }
                }
            }
            throw new InvalidOperationException();
        }

        public static void GetCourseDate(ref string[] tab)
        {
            XmlTextReader reader = new XmlTextReader("http://api.nbp.pl/api/exchangerates/rates/a/usd/last/30/?format=xml");
            int i = 29;
            while (reader.Read())
            {
                if(reader.IsStartElement())
                {
                    switch(reader.Name.ToString())
                    {
                        case "EffectiveDate":
                        tab[i] = reader.ReadString();
                        i--;
                        break;
                    }
                }
            }

        }

        public static void GetCourseStatistic(ref float[,] tab, string CurrencyName)
        {
            int a = 0;
            if (CurrencyName == "usd")
                a = 0;
            if (CurrencyName == "eur")
                a = 1;
            if (CurrencyName == "gbp")
                a = 2;
            if (CurrencyName == "chf")
                a = 3;

            XmlTextReader reader = new XmlTextReader("http://api.nbp.pl/api/exchangerates/rates/a/"+CurrencyName+"/last/30/?format=xml");
            int i = 29;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "Mid":
                            tab[i,a] = Helpes.StringToFloat(reader.ReadString());
                            i--;
                            break;
                    }
                }
            }
        }
        
        public static float ConvertPlnToOthe(float course, float valueTextBox)
        {
            course = 1 / course;
            valueTextBox = valueTextBox * course;
            return valueTextBox;
        }
        public static float ConvertOthersToPln(float course, float valueTextBox)
        {
            valueTextBox = valueTextBox * course;
            return valueTextBox;
        }
        public static float ConvertOtherstoOthers(float course1, float course2, float valueTextBox)
        {
            float tmp = course1 / course2;
            valueTextBox = valueTextBox * tmp;
            return valueTextBox;
        }

    }
}
