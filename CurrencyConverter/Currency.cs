using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Currency
    {
        public string Date { get; set; }
        public string UsdCourse { get; set; }
        public string EurCourse { get; set; }
        public string GbpCourse { get; set; }
        public string ChfCourse { get; set; }

        public Currency(string date, string usdCourse, string eurCourse, string gbpCourse, string chfCourse)
        {
            this.Date = date;
            this.UsdCourse = usdCourse;
            this.EurCourse = eurCourse;
            this.GbpCourse = gbpCourse;
            this.ChfCourse = chfCourse;
        }
    }
}
