using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsMethod.Controller
{
    public class DataParser
    {
        public double StringConvertingToDouble(string value)
        {
            var provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";
            return Convert.ToDouble(value, provider);
        }

        public int StringConvertingToInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}