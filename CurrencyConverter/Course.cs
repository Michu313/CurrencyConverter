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

        #region get all currency names
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
        #endregion

        #region get date from last 30 day 
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
        #endregion

        #region get statistic currency from last 30 day 
        public static void GetCourseStatistic(ref double[] tab, string CurrencyName, string[] date)
        {
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/rates/a/"+CurrencyName.ToLower()+"/last/30/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            GetCourseStatisticLooop(ref tab, xd, date);
        }
        
        private static void GetCourseStatisticLooop(ref double[] tab, XmlDocument xml, string[] date)
        {
            int i = 29;
            foreach (XmlNode item in xml.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    XmlElement w = (XmlElement)pp.GetElementsByTagName("EffectiveDate")[0];
                    if (w.InnerText == date[i])
                    {
                       tab[i] = Convert.ToDouble(Helper.StringToFloat(Convert.ToString(pp.GetElementsByTagName("Mid")[0].InnerText)));
                        i--; 
                    }
                }
            }
            
        }
        #endregion



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
