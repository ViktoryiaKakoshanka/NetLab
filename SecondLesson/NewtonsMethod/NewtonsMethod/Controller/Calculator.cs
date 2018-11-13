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
            radicalSign.Result = ComputeRadicalWithAccuracy(radicalSign);
            return radicalSign.Result;
        }
        
        public double CalculateMathPow(IRadicalSign radicalSign)
        {
            return Math.Pow(radicalSign.Result, radicalSign.Power);
        }

        private double ComputeRadicalWithAccuracy(IRadicalSign radicalSign)
        {
            double currentAccuracy;
            var stepPassed = false;
            var previousRadical = 1.0;
            var currentRadical = 1.0;

            do
            {
                if (stepPassed) previousRadical = currentRadical;

                currentRadical = CalculateCurrentRadicalByMethodNewton(radicalSign, previousRadical);
                stepPassed = true;
                currentAccuracy = Math.Abs(previousRadical - currentRadical);

            } while (currentAccuracy > radicalSign.Accuracy);

            return currentRadical;
        }

        private double CalculateCurrentRadicalByMethodNewton(IRadicalSign radicalSign, double previousRadical)
        {
            var previousPower = ErectInDegree(previousRadical, radicalSign.Power - 1);
            var firstPartCalculation = 1.0 / radicalSign.Power;
            var secondPartCalculation = (radicalSign.Power - 1.0) * previousRadical + radicalSign.NumericalRoot / previousPower;

            var currentRadical = firstPartCalculation * secondPartCalculation;
            return currentRadical;
        }

        /// <summary>
        /// Raising a number to a power
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="power">power</param>
        /// <returns>number {value} in degree {power}</returns>
        private double ErectInDegree(double number, int power)
        {
            var numberConst = number;
            for (var counter = 2; counter <= power; counter++)
            {
                number *= numberConst;
            }
            return number;
        }

    }
}
