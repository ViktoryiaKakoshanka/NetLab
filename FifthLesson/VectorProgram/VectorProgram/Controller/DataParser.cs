using System;

namespace VectorProgram.Controller
{
    public class DataParser
    {
        public static double[] ParseUserInput(string inputData)
        {
            var arr = inputData.Split(' ');
            var arrResult = new double[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToDouble(arr[i]);
            }

            return arrResult;
        }
    }
}
