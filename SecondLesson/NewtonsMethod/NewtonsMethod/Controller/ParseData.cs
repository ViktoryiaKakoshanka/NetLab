using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsMethod.Controller
{
    class ParseData
    {
        public double StringConvertingToDouble(string value)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";
            return Convert.ToDouble(value, provider);
        }

        public int StringConvertingToInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}
