using System;

namespace NewtonsMethod.Controller
{
    public class Calculator
    {
        public static int Compare(double number, int power, double accuracy, out double delta)
        {
            var rootNewton = CalculateRootByMethodNewtons(number, power, accuracy);
            var rootMath = CalculateRootNumberByMath(number, power);

            delta = Math.Abs(rootNewton - rootMath);
            if (rootNewton > rootMath)
            {
                return 1;
            }

            return (rootNewton < rootMath) ? -1 : 0;
        }


        public static double CalculateRootNumberByMath(double number, int power)
        {
            return Math.Pow(number, 1.0 / power);
        }

        public static double CalculateRootByMethodNewtons(double number, int power, double accuracy)
        {
            double currentAccuracy;
            var previousRoot = 1.0;
            double result;

            do
            {
                result = CalculateCurrentRadical(number, power, previousRoot);
                currentAccuracy = Math.Abs(previousRoot - result);
                previousRoot = result;

            } while (currentAccuracy > accuracy);

            return result;
        }

        private static double CalculateCurrentRadical(double number, int power, double previousRoot)
        {
            var previousPower = Math.Pow(previousRoot, power - 1);
            return 1.0 / power * ((power - 1.0) * previousRoot + number / previousPower);
        }
    }
}