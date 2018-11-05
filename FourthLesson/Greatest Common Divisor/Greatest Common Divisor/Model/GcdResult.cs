<<<<<<< Updated upstream
﻿namespace Greatest_Common_Divisor.Model
=======
﻿using System.Collections;
using System.Collections.Generic;

namespace Greatest_Common_Divisor.Model
>>>>>>> Stashed changes
{
    public class GcdResult
    {
        public int Gcd { get; set; }
        public int IterationsCount { get; set; }
<<<<<<< Updated upstream
=======
        private IDictionary<int, int[]> calculationHistory = new Dictionary<int, int[]>();

        public void AddCalculationHistory(int a, int b, int step)
        {
            calculationHistory.Add(step, new[] { a, b });
        }

        public void ClearCalculationHistory()
        {
            calculationHistory.Clear();
        }

        public IDictionary<int, int[]> GetCalculationHistory()
        {
            return calculationHistory;
        }        
>>>>>>> Stashed changes
    }
}
