using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greatest_Common_Divisor.Algorithms;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor
{
    public class Driver
    {
        public static GcdResult Calculate(int[] numbers, AlgorithmType algorithmType)
        {
            var algorithm = GetAlgorithm(algorithmType);
            return algorithm.Calculate(numbers);
        }
        
        private static IAlgorithmGcd GetAlgorithm(AlgorithmType algorithmType)
        {
            return new AlgorithmFactory().Algorithm(algorithmType);
        }
        
        public static string FormatResult(IEnumerable<int> numbers, GcdResult result)
        {
            var s = new StringBuilder();

            s.Append("GCD( ")
                .Append(string.Concat(numbers.Select(x => $"{x.ToString()} ")))
                .Append($") = {result.GreatestCommonDivisor}")
                .Append(result.NumberOfIterations == 0 ? "\n" : $" and number of iterations = {result.NumberOfIterations}\n");

            return s.ToString();
        }
    }
}
