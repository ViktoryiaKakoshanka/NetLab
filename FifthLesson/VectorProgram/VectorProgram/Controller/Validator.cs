using System.Collections.Generic;
using System.Text.RegularExpressions;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> validationRules = new Dictionary<DataType, string>
        {
            {DataType.Multiplier, @"\d+\[.,]\d+|\d+" },
            {DataType.Vector, @"^\d+\[.,]\d+|\d+ \d+\[.,]\d+|\d+ \d+\[.,]\d+|\d+$" },
            {DataType.Power, @"\d+$" },
            {DataType.Monomial, @"\d+\[.,]\d+|\d+" },
        };

        public static bool ValidateInput(DataType dataType, string input)
        {
            Regex regex = new Regex(validationRules[dataType]);
            return regex.IsMatch(input);
        }
    }
}