using System.Collections.Generic;
using System.Text.RegularExpressions;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> validationRules = new Dictionary<DataType, string>
        {
            {DataType.Multiplier, @"\d+\[.|,]\d+|\d+" },
            {DataType.Vector, @"^[0-9]{1,9} [0-9]{1,9} [0-9]{1,9}$" }
        };

        public static bool ValidateInput(DataType dataType, string input)
        {
            Regex regex = new Regex(validationRules[dataType]);
            return regex.IsMatch(input);

        }
    }
}