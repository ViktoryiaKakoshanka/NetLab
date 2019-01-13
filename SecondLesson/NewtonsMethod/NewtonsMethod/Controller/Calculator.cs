using System;

namespace NewtonsMethod.Controller
{
    public class Calculator
    {
        public static int Compare(double number, int power, double accuracy, out double delta)
        {
            var rootNewton = CalculateRootNumberByNewtons(number, power, accuracy);
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
            return Math.Pow(number, (int)(1/power));
        }

        public static double CalculateRootNumberByNewtons(double number, int power, double accuracy)
        {
            double currentAccuracy;
            var previousRadical = 1.0;
            double currentRadical;

            do
            {
                currentRadical = CalculateCurrentRadical(number, power, previousRadical);
                currentAccuracy = Math.Abs(previousRadical - currentRadical);
                previousRadical = currentRadical;

            } while (currentAccuracy > accuracy);

            return currentRadical;
        }

        private static double CalculateCurrentRadical(double number, int power, double previousRadical)
        {
            var previousPower = Math.Pow(previousRadical, power - 1);
            return 1.0 / power * ((power - 1.0) * previousRadical + number / previousPower);
        }
    }
}