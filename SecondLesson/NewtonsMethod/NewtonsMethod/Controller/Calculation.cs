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
        public double CalculateRadicalSignByMethodNewton(IRadicalSign radicalSign)
        {
            var currentRadical = ComputeRadicalWithAccuracy(radicalSign);

            radicalSign.SetResult(currentRadical);

            return currentRadical;
        }

        private double ComputeRadicalWithAccuracy(IRadicalSign radicalSign)
        {
            double delta;
            var step = 1;
            var previousRadical = 1.0;
            var currentRadical = 1.0;
            do
            {
                if (step > 1)
                {
                    previousRadical = currentRadical;
                }

                xNext = (1.0 / radicalSign.GetPower()) * ((radicalSign.GetPower()-1.0) * xPrev + radicalSign.GetNumericalRoot() / Exponentiation(xPrev, (radicalSign.GetPower() - 1)));
                step = 2;
                delta = Math.Abs(xPrev-xNext);

            } while (delta > radicalSign.GetAccuracy());
            return delta;
        }

        private double CalculateCurrentRadical(IRadicalSign radicalSign, double previousRadical)
        {
            double currentRadical;
            var power = Exponentiation(previousRadical, radicalSign.GetPower() - 1);
            var a = 1.0 / radicalSign.GetPower();
            var b = (radicalSign.GetPower() - 1.0) * previousRadical + radicalSign.GetNumericalRoot() / power;
            currentRadical = a * b;
            return currentRadical;
        }

        public double MathPow(IRadicalSign radicalSign)
        {
            var result = Math.Pow(radicalSign.GetResult(), radicalSign.GetPower());

            return result;
        }

        /// <summary>
        /// Raising a number to a power
        /// </summary>
        /// <param name="value">number</param>
        /// <param name="power">power</param>
        /// <returns>number {value} in degree {power}</returns>
        private double Exponentiation(double value, int power)
        {
            var valueConst = value;
            for (var i = 2; i <= power; i++)
            {
                value *= valueConst;
            }
            return value;
        }
    }
}
