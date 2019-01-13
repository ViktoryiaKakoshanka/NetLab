using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> ValidationRules = new Dictionary<DataType, string>
        {
            {DataType.Number, @"\d+\[.,]\d+|\d+" },
            {DataType.Power, @"\d+$" },
            {DataType.Accuracy, @"^0[.,]\d+|1$" }
        };

        public static bool ValidateInput(string input, DataType param)
        {
            var regex = new Regex(ValidationRules[param]);
            return regex.IsMatch(input);
        }
    }
}
