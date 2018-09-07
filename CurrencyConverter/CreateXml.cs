using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConverter.OfflineCourseCurrent
{
    class CreateXml
    {
        public CreateXml()
        {
            CreateXmlDocument(GetListCurrencyXml(), GetDateFromXml());
        }

        private List<CurrencyXml> GetListCurrencyXml()
        {
            List<CurrencyXml> list = new List<CurrencyXml>();
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            foreach (XmlNode item in xd.GetElementsByTagName("Rate"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    list.Add(new CurrencyXml( pp.GetElementsByTagName("Currency")[0].InnerText, pp.GetElementsByTagName("Code")[0].InnerText, pp.GetElementsByTagName("Mid")[0].InnerText));
                }
            }
            return list;
        }
        private string GetDateFromXml()
        {
            string date="";
            var wc = new WebClient();
            var course = wc.DownloadString("http://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(course);
            foreach (XmlNode item in xd.GetElementsByTagName("ExchangeRatesTable"))
            {
                if (item.NodeType == XmlNodeType.Element)
                {
                    XmlElement pp = (XmlElement)item;
                    date = pp.GetElementsByTagName("EffectiveDate")[0].InnerText;
                }
            }
            return date;
        }
        /// <summary>
        /// create xml file to offline mode 
        /// </summary>
        /// <param name="currencies">list current</param>
        /// <param name="date">date </param>
        private void CreateXmlDocument(List<CurrencyXml> currencies, string date)
        {
            XDocument xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("ExchangeRatesTable",
            new XElement("EffectiveDate", date ),
            new XElement("Rates",
            from rate in currencies
            select new XElement("Rate",
            new XElement("Currency", rate.Currency),
            new XElement("Code", rate.Code),
            new XElement("Mid", rate.Mid)
            ))));
            xml.Save(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "") + "\\OfflineCourseCurrent\\OfflineMode.xml");
        }

    }
}
