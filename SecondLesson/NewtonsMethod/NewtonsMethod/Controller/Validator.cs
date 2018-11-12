﻿using NewtonsMethod.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class Validator
    {
        private static IDictionary<InputedParams, string> validationRules = new Dictionary<InputedParams, string>
        {
            {InputedParams.Numerical, @"\d+\.\d+|\d+" },
            {InputedParams.Power, @"\d+" },
            {InputedParams.Аccurancy, @"0\.\d+|1" }
        };

        public static bool ValidateInput(string input, InputedParams param)
        {
            Regex regex = new Regex(validationRules[param]);
            return regex.IsMatch(input);
        }
    }
}
