using System;

namespace NewtonsMethod.Controller
{
    public static class Calculator
    {
        public static double CalculateRootNumberByMath(double number, int rootPower)
        {
            return Math.Pow(number, 1.0 / rootPower);
        }

        public static double CalculateRootByMethodNewtons(double number, int rootPower, double accuracy)
        {
            double currentAccuracy;
            var previousRoot = 1.0;
            double result;

            do
            {
                result = CalculateCurrentRadical(number, rootPower, previousRoot);
                currentAccuracy = Math.Abs(previousRoot - result);
                previousRoot = result;

            } while (currentAccuracy > accuracy);

            return result;
        }

        private static double CalculateCurrentRadical(double number, int rootPower, double previousRoot)
        {
            var previousPower = Math.Pow(previousRoot, rootPower - 1);
            return 1.0 / rootPower * ((rootPower - 1.0) * previousRoot + number / previousPower);
        }
    }
}