using System;
using System.Globalization;

namespace NewtonsMethod.Controller
{
    public class DataParser
    {
        public double ParseStringToDouble(string value)
        {
            var provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";
            return Convert.ToDouble(value, provider);
        }

        public int ParseStringToInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}