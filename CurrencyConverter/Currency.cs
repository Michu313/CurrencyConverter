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
        public double Variable1 { get; private set; }
        public double Value1 { get; private set; }
        public string Data { get; private set; }
        public double Value2 { get; private set; }
        public double Variable2 { get; private set; }
        public string CourseImage2 { get; private set; }

        public Currency(string courseImage1, double variable1, double value1, string date, double value2, double variable2, string courseImage2)
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
