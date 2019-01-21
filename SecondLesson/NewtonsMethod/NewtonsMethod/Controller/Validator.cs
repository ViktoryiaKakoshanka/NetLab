using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<ValidationType, string> ValidationRules = new Dictionary<ValidationType, string>
        {
            {ValidationType.Number, @"\d+\[.,]\d+|\d+" },
            {ValidationType.RootPower, @"\d+$" },
            {ValidationType.Accuracy, @"^0[.,]\d+|1$" }
        };

        public static bool ValidateInput(string input, ValidationType param)
        {
            var regex = new Regex(ValidationRules[param]);
            return regex.IsMatch(input);
        }
    }
}
