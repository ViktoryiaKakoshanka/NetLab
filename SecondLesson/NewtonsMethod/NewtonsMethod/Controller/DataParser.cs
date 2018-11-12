using System;
using System.Globalization;

namespace NewtonsMethod.Controller
{
    public class DataParser
    {
        public double TransformStringToDouble(string value)
        {
            var provider = new NumberFormatInfo();
            provider.CurrencyDecimalSeparator = ".";
            return Convert.ToDouble(value, provider);
        }

        public int TransformStringToInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}
