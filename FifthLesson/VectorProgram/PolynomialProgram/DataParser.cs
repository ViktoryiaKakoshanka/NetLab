using System.Globalization;
using System.Linq;

namespace PolynomialProgram
{
    public class DataParser
    {
        public static double[] ParseArray(string inputData)
        {
            var arr = inputData.Trim().Split(' ');
            return arr.Select(ParseDouble).ToArray();
        }

        public static double ParseDouble(string inputData)
        {
            return double.Parse(inputData.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}