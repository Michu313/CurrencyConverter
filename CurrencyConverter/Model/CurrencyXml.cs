using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class CurrencyXml
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Mid { get; set; }

        public CurrencyXml(string currency, string code, string mid)
        {
            this.Currency = currency;
            this.Code = code;
            this.Mid = mid;
        }
    }
}
