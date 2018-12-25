using Greatest_Common_Divisor.GCDAlgorithm;
using Greatest_Common_Divisor.Model;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace GreatestCommonDivisorProgram.View
{
    class GcdCalculationDriver
    {
        public int[] Numbers { get; private set; }
        public GcdResult Result { get; private set; }

        public GcdCalculationDriver()
        {
            Numbers = new int[0];
            Result = new GcdResult();
        }

        public void CalculateGcd(string userInput, GcdAlgorithmType algorithmType)
        {
            var algorithm = GetAlgorithmByType(algorithmType);
            Result = CalculateGcd(userInput, algorithm);
        }

        public string GetFormatedResult()
        {
            var s = new StringBuilder();
            s.AppendFormat("{0}", "НОД( ");
            foreach (var number in Numbers)
            {
                s.AppendFormat("{0} ", number.ToString());
            }
            s.Append($") = {Result.Gcd}");
            s.Append((Result.IterationsCount == 0) ? "\n" : $" и кол-во итераций = {Result.IterationsCount}\n");
            return s.ToString();
        }

        private static IAlgorithmGcd GetAlgorithmByType(GcdAlgorithmType algorithmType)
        {
            var algorihtmFactory = new GcdAlgorithmFactory();
            return algorihtmFactory.GetAlgorithm(algorithmType);
        }

        private static bool ValidateUserInput(string userInput)
        {
            var regex = new Regex(@"^[0-9]{1,3} [0-9]{1,3}( [0-9]{1,3})?( [0-9]{1,3})?( [0-9]{1,3})?$");
            return (regex.IsMatch(userInput));
        }

        private static int[] ParseUserInput(string userInput)
        {
            var arr = userInput.Split(' ');
            var arrResult = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToInt32(arr[i]);
            }

            return arrResult;
        }

        private GcdResult CalculateGcd(string userInput, IAlgorithmGcd algorithm)
        {
            if (!ValidateUserInput(userInput))
            {
                return null;
            }

            Numbers = ParseUserInput(userInput);
            return algorithm.Calculate(Numbers);
        }
    }
}
