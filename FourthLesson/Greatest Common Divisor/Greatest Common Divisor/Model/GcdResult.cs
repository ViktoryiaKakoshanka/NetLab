using System.Collections.Generic;

namespace Greatest_Common_Divisor.Model
{
    public class GcdResult
    {
        public int GreatestCommonDivisor { get; set; }
        public int NumberOfIterations { get; set; }
        private readonly IDictionary<int, int[]> _calculationHistory = new Dictionary<int, int[]>();

        public void AddCalculationHistory(int firstNumber, int secondNumber, int step)
        {
            _calculationHistory.Add(step, new[] { firstNumber, secondNumber });
        }
        
        public IDictionary<int, int[]> GetCalculationHistory()
        {
            return _calculationHistory;
        }        
    }
}