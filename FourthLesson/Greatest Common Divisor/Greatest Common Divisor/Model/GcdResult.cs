using System.Collections.Generic;

namespace Greatest_Common_Divisor.Model
{
    public class GcdResult
    {
        public int GreatestCommonDivisor { get; set; }
        public int IterationsCount { get; set; }
        private readonly IDictionary<int, int[]> _calculationHistory = new Dictionary<int, int[]>();

        public GcdResult()
        {
            
        }

        public GcdResult(int greatestCommonDivisor, int iterationsCount)
        {
            GreatestCommonDivisor = greatestCommonDivisor;
            IterationsCount = iterationsCount;
        }

        public GcdResult(int greatestCommonDivisor, int iterationsCount, IDictionary<int, int[]> calculationHistory)
        {
            GreatestCommonDivisor = greatestCommonDivisor;
            IterationsCount = iterationsCount;
            if (calculationHistory != null)
            {
                _calculationHistory = calculationHistory;
            }
        }

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