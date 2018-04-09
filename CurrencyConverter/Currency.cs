using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {
        public string Date { get; private set; }
        public float UsdCourse { get; private set; }
        public string UsdCourseImage { get; private set; }
        public float EurCourse { get; private set; }
        public string EurCourseImage { get; private set; }
        public float GbpCourse { get; private set; }
        public string GbpCourseImage { get; private set; }
        public float ChfCourse { get; private set; }
        public string ChfCourseImage { get; private set; }

        public Currency(string date, float usdCourse, string usdCourseImage, float eurCourse, string eurCourseImage, float gbpCourse, string gbpCourseImage, float chfCourse, string chfCourseImage)
        {
            this.Date = date;
            this.UsdCourse = usdCourse;
            this.UsdCourseImage = usdCourseImage;
            this.EurCourse = eurCourse;
            this.EurCourseImage = eurCourseImage;
            this.GbpCourse = gbpCourse;
            this.GbpCourseImage = gbpCourseImage;
            this.ChfCourse = chfCourse;
            this.ChfCourseImage = chfCourseImage;
        }
    }
}
