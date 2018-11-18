using System;
using System.Globalization;

namespace VectorProgram.Controller
{
    public class DataParser
    {
        public static double[] ParseStringToArray(string inputData)
        {
            var arr = inputData.Trim(' ').Split(' ');
            var arrResult = new double[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToDouble(arr[i]);
            }

            return arrResult;
        }

        public static double DoubleTryParse(string inputData)
        {
            double.TryParse(inputData.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out double result);
            return result;
        }

        public static int IntTryParse(string inputData)
        {
            int.TryParse(inputData.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out int result);
            return result;
        }
    }
}
