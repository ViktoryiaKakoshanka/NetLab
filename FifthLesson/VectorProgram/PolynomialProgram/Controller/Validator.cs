using System.Collections.Generic;
using System.Text.RegularExpressions;
using PolynomialProgram.Model;

namespace PolynomialProgram.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> ValidationRules = new Dictionary<DataType, string>
        {
            {DataType.Multiplier, @"\d+\[.,]\d+|\d+" },
            {DataType.Vector, @"^\d+\[.,]\d+|\d+ \d+\[.,]\d+|\d+ \d+\[.,]\d+|\d+$" },
            {DataType.Power, @"\d+$" },
            {DataType.Monomial, @"\d+\[.,]\d+|\d+" },
        };

        public static bool ValidateInput(DataType dataType, string input)
        {
            var regex = new Regex(ValidationRules[dataType]);
            return regex.IsMatch(input);
        }
    }
}