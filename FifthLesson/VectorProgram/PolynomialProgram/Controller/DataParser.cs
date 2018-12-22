﻿using System.Globalization;

namespace PolynomialProgram.Controller
{
    public class DataParser
    {
        public static double[] ParseArray(string inputData)
        {
            var arr = inputData.Trim(' ').Split(' ');
            var arrResult = new double[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = ParseDouble(arr[i]);
            }

            return arrResult;
        }

        public static double ParseDouble(string inputData)
        {
            return double.Parse(inputData.Replace(",", "."), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
