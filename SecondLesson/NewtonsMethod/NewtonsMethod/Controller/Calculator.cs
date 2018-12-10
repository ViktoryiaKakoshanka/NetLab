using System;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public class Calculator: ICalculator
    {
        /// <summary>
        /// Calculation of the nth root of a number by the Newton method with a given accuracy
        /// </summary>
        /// <param name="radicalSign"></param>
        /// <returns></returns>
        public double CalculateRadicalSign(IRadicalSign radicalSign)
        {
            var root = ComputeRadicalWithAccuracy(radicalSign);
            radicalSign.SetRoot(root);
            return root;
        }
        
        public double CalculateMathPow(IRadicalSign radicalSign) => Math.Pow(radicalSign.Root, radicalSign.Power);

        private double ComputeRadicalWithAccuracy(IRadicalSign radicalSign)
        {
            double currentAccuracy;
            var previousRadical = 1.0;
            var currentRadical = 1.0;

            do
            {
                currentRadical = CalculateCurrentRadicalByMethodNewton(radicalSign, previousRadical);
                currentAccuracy = Math.Abs(previousRadical - currentRadical);
                previousRadical = currentRadical;

            } while (currentAccuracy > radicalSign.Accuracy);

            return currentRadical;
        }

        private double CalculateCurrentRadicalByMethodNewton(IRadicalSign radicalSign, double previousRadical)
        {
            var previousPower = ErectInDegree(previousRadical, radicalSign.Power - 1);
            var firstPartCalculation = 1.0 / radicalSign.Power;
            var secondPartCalculation = (radicalSign.Power - 1.0) * previousRadical + radicalSign.Number / previousPower;

            return firstPartCalculation * secondPartCalculation;
        }

        /// <summary>
        /// Raising a number to a power
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="power">power</param>
        /// <returns>number {value} in degree {power}</returns>
        private double ErectInDegree(double number, int power)
        {
            if (power <= 1)
            {
                return number;
            }

            return number * ErectInDegree(number, --power);
        }

    }
}
