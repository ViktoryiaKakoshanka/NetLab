using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class Validator
    {
        private static readonly IDictionary<DataType, string> ValidationRules = new Dictionary<DataType, string>
        {
<<<<<<< HEAD
            {DataType.Numerical, @"\d+\[.,]\d+|\d+" },
            {DataType.Power, @"\d+$" },
            {DataType.Accuracy, @"^0[.,]\d+|1$" }
=======
            { DataType.Numerical, @"\d+\[.,]\d+|\d+" },
            { DataType.Power, @"\d+$" },
            { DataType.Аccurancy, @"^0[.,]\d+|1$" }
>>>>>>> master
        };

        public static bool ValidateInput(string input, DataType param)
        {
            Regex regex = new Regex(ValidationRules[param]);
            return regex.IsMatch(input);
        }
    }
}
