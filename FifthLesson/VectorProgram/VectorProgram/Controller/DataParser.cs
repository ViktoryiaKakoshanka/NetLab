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
                arrResult[i] = ParseToDouble(arr[i]);
            }

            return arrResult;
        }

        public static double ParseToDouble(string inputData)
        {
            return double.Parse(inputData.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static int ParseToInt(string inputData)
        {
            return int.Parse(inputData);
        }
    }
}
