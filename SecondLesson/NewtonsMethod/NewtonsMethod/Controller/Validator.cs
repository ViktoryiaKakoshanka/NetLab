using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> validationRules = new Dictionary<DataType, string>
        {
            { DataType.Numerical, @"\d+\[.,]\d+|\d+" },
            { DataType.Power, @"\d+$" },
            { DataType.Аccurancy, @"^0[.,]\d+|1$" }
        };

        public static bool ValidateInput(string input, DataType param)
        {
            Regex regex = new Regex(validationRules[param]);
            return regex.IsMatch(input);
        }
    }
}
