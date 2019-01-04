using System.Collections.Generic;

namespace Greatest_Common_Divisor.Model
{
    public class GcdResult
    {
        public int GreatestCommonDivisor { get; set; }
        public int IterationsCount { get; set; }

        public IDictionary<int, int[]> CalculationHistory { get; }

        public GcdResult()
        {
            CalculationHistory = new Dictionary<int, int[]>();
        }

        public void AddCalculationHistory(int firstNumber, int secondNumber, int step)
        {
            CalculationHistory.Add(step, new[] { firstNumber, secondNumber });
        }
    }
}