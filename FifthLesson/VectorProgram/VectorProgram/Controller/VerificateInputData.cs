using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VectorProgram.Model;

namespace VectorProgram.Controller
{
    public static class VerificateInputData
    {
        public static bool VerifyInputDataCoordsVector(string inputData)
        {
            var regex = new Regex(@"^[0-9]{1,9} [0-9]{1,9} [0-9]{1,9}$");
            return (regex.IsMatch(inputData));
        }

        public static bool ValidateUserInputDouble(string inputData)
        {
            var regex = new Regex(@"^[0-9]{1,9}$");
            return (regex.IsMatch(inputData));
        }

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
