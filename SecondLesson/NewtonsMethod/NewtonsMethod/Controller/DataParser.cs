using System;
using System.Globalization;

namespace NewtonsMethod.Controller
{
    public class DataParser
    {
        public double ParseDouble(string value)
        {
            var provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";

            return Convert.ToDouble(value, provider);
        }

        public int ParseInt(string value) => Convert.ToInt32(value);
    }
}