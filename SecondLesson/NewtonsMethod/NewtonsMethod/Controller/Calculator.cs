using System;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public class Calculator
    {
        public static double CalculateRadicalSign(IRadicalSign radicalSign)
        {
            var root = CalculateRadicalWithAccuracy(radicalSign);
            radicalSign.SetRoot(root);
            return root;
        }
        
        public static double CalculateRootNumber(IRadicalSign radicalSign) => Math.Pow(radicalSign.Root, radicalSign.Power);

        private static double CalculateRadicalWithAccuracy(IRadicalSign radicalSign)
        {
            double currentAccuracy;
            var previousRadical = 1.0;
            double currentRadical;

            do
            {
                currentRadical = CalculateCurrentRadical(radicalSign, previousRadical);
                currentAccuracy = Math.Abs(previousRadical - currentRadical);
                previousRadical = currentRadical;

            } while (currentAccuracy > radicalSign.Accuracy);

            return currentRadical;
        }

        private static double CalculateCurrentRadical(IRadicalSign radicalSign, double previousRadical)
        {
            var previousPower = ErectInDegree(previousRadical, radicalSign.Power - 1);
            var firstPartCalculation = 1.0 / radicalSign.Power;
            var secondPartCalculation = (radicalSign.Power - 1.0) * previousRadical + radicalSign.Number / previousPower;

            return firstPartCalculation * secondPartCalculation;
        }
        
        private static double ErectInDegree(double number, int power)
        {
            if (power <= 1)
            {
                return number;
            }

            return number * ErectInDegree(number, --power);
        }
    }
}