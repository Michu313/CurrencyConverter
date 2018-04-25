using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace CurrencyConverter
{
    public class Course
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

        private static int GetIloscWalut()
        {
            int i = 0;
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
                    i++;
                }
            }
            return i;
        }

        public static string[] GetAllNameCurrent()
        {
            int i = 0;
            string[] tab = new string[Course.GetIloscWalut()];
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            foreach (XmlNode item in xd.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    tab[i] = pp.GetElementsByTagName("Code")[0].InnerText;
                    i++;
                }
            }
            return tab;
        }

        public static void GetCourseDate(ref string[] tab)
        {
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/rates/a/usd/last/30/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            Course.GetCourseDateLoop(ref tab, xd);
        }

        private static void GetCourseDateLoop(ref string[] tab, XmlDocument a)
        {
            int i = 29;
            foreach (XmlNode item in a.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    tab[i]=Convert.ToString(pp.GetElementsByTagName("EffectiveDate")[0].InnerText);
                    i--;
                }
            }
        }

        private static int NameCurrent(string a)
        {
            int tmp = 0;
            if (a == "usd")
                tmp = 0;
            if (a == "eur")
                tmp = 1;
            if (a == "gbp")
                tmp = 2;
            if (a == "chf")
                tmp = 3;
            return tmp;
        }

        public static void GetCourseStatistic(ref float[,] tab, string CurrencyName)
        {
            int a = Course.NameCurrent(CurrencyName);
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/rates/a/" + CurrencyName + "/last/30/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            Course.GetCourseStatisticLooop(ref tab, xd, a);
        }

        private static void GetCourseStatisticLooop(ref float[,] tab, XmlDocument xml, int a)
        {
            int i = 29;
            foreach (XmlNode item in xml.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    tab[i,a] = Helper.StringToFloat(Convert.ToString(pp.GetElementsByTagName("Mid")[0].InnerText));
                    i--;
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
