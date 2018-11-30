using System;
using System.Globalization;

namespace NewtonsMethod.Controller
{
    public static class DataParser
    {
        public static double ParseDouble(string value)
        {
            var provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";

            return Convert.ToDouble(value, provider);
        }

        public static int ParseInt(string value) => Convert.ToInt32(value);
    }
}