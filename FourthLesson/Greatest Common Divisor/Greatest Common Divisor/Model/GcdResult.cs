using System.Collections.Generic;

namespace Greatest_Common_Divisor.Model
{
    public class GcdResult
    {
        public int Gcd { get; set; }
        public int IterationsCount { get; set; }

        private IDictionary<int, int[]> calculationHistory = new Dictionary<int, int[]>();

        public void AddCalculationHistory(int firstNumber, int secondNumber, int step)
        {
            calculationHistory.Add(step, new[] { firstNumber, secondNumber });
        }

        public void ClearCalculationHistory()
        {
            calculationHistory.Clear();
        }

        public IDictionary<int, int[]> GetCalculationHistory()
        {
            return calculationHistory;
        }        

    }
}