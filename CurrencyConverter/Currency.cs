using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {
        public string CourseImage1 { get; private set; }
        public float Variable1 { get; private set; }
        public float Value1 { get; private set; }
        public string Data { get; private set; }
        public float Value2 { get; private set; }
        public float Variable2 { get; private set; }
        public string CourseImage2 { get; private set; }

        public Currency(string courseImage1, float variable1, float value1, string date, float value2, float variable2, string courseImage2)
        {
            this.CourseImage1 = courseImage1;
            this.Variable1 = variable1;
            this.Value1 = value1;
            this.Data = date;
            this.Value2 = value2;
            this.Variable2 = variable2;
            this.CourseImage2 = courseImage2;
        }
    }
}
