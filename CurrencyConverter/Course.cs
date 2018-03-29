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

        public static void GetCourse(string currently, ref string[] tab, ref string[] tabUSD)
        {
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            for(int i = 0;i<tab.Length;i++)
            {
            foreach (XmlNode item in xd.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    XmlElement w = (XmlElement)pp.GetElementsByTagName("EffectiveDate")[0];
                    if (w.InnerText != tab[i])
                    {
                        tab[i]= Convert.ToString(pp.GetElementsByTagName("EffectiveDate")[0].InnerText);
                        tabUSD[i]= Convert.ToString(pp.GetElementsByTagName("Mid")[0].InnerText);
                    }
                }
            }
            }
            throw new InvalidOperationException();
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
