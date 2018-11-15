using System;

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
    }
}
