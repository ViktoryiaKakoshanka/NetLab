using System.Text.RegularExpressions;

namespace NewtonsMethod.Controller
{
    public static class ValidationInput
    {
        public static bool InputUserPower(string power)
        {
            Regex regex = new Regex(@"\d+");
            return (regex.IsMatch(power));
        }

        public static bool InputUserNumericalRoot(string numericalRoot)
        {
            Regex regex = new Regex(@"\d+\.\d+|\d+");
            return (regex.IsMatch(numericalRoot));
        }

        public static bool InputUserАccurancy(string accurancy)
        {
            Regex regex = new Regex(@"0\.\d+|1");
            return (regex.IsMatch(accurancy));
        }
    }
}
