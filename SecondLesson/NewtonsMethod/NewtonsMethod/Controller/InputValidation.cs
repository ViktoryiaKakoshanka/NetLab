using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class InputValidation
    {
        public static bool ValidateUserInputPower(string power)
        {
            Regex regex = new Regex(@"\d+");
            return (regex.IsMatch(power));
        }

        public static bool ValidateUserInputNumericalRoot(string numericalRoot)
        {
            Regex regex = new Regex(@"\d+\.\d+|\d+");
            return (regex.IsMatch(numericalRoot));
        }

        public static bool ValidateUserInputАccurancy(string accurancy)
        {
            Regex regex = new Regex(@"0\.\d+|1");
            return (regex.IsMatch(accurancy));
        }
    }
}
