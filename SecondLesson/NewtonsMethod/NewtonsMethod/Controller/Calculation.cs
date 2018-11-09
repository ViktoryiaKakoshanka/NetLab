using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public class Calculator: ICalculator
    {
        /// <summary>
        /// Вычисление корня n-ой степени из числа методом Ньютона с заданной точностью
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

                currentRadical = CalculateCurrentRadical(radicalSign, previousRadical);

                step = 2;

                delta = Math.Abs(previousRadical - currentRadical);

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
        /// Возведение числа в степень
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="power">стерень</param>
        /// <returns>число {value} в степени {power}</returns>
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
