using System;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public class Calculation: ICalculation
    {
        /// <summary>
        /// Calculation of the nth root of a number by the Newton method with a given accuracy
        /// </summary>
        /// <param name="radicalSign"></param>
        /// <returns></returns>
        public double RadicalSignByMethodNewton(IRadicalSign radicalSign)
        {
            var xPrev = 1.0;
            var xNext = 1.0;
            var step = 1;
            double delta;

            do
            {
                if(step>1)
                {
                    xPrev = xNext;
                }

                xNext = (1.0 / radicalSign.GetPower()) * ((radicalSign.GetPower()-1.0) * xPrev + radicalSign.GetNumericalRoot() / Exponentiation(xPrev, (radicalSign.GetPower() - 1)));
                step = 2;
                delta = Math.Abs(xPrev-xNext);

            } while (delta>radicalSign.GetAccuracy());

            radicalSign.SetResult(xNext);

            return radicalSign.GetResult();
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
            for (var i = 2; i<=power; i++)
            {
                value *= valueConst;
            }
            return value;
        }

        public double MathPow(IRadicalSign radicalSign)
        {
            var result = Math.Pow(radicalSign.GetResult(), radicalSign.GetPower());

            return result;
        }
    }
}
