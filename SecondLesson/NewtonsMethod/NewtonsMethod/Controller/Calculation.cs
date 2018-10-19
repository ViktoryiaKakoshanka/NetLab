using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    class Calculation
    {
        /// <summary>
        /// Вычисление корня n-ой степени из числа методом Ньютона с заданной точностью
        /// </summary>
        /// <param name="radicalSign"></param>
        /// <returns></returns>
        public double ComputationRootByMethodNewton(RadicalSign radicalSign)
        {
            var xPrev = 1.0;
            var xNext = 1.0;
            var step = 1;

            do
            {
                if(step>1)
                {
                    xPrev = xNext;
                }

                xNext = (1.0 / radicalSign.GetPower()) * ((radicalSign.GetPower()-1.0) * xPrev + radicalSign.GetNumericalRoot() / Exponentiation(xPrev, (radicalSign.GetPower() - 1)));

                step = 2;

            } while ((xPrev-xNext)<=radicalSign.GetAccuracy());

            radicalSign.SetResult(xNext);

            return radicalSign.GetResult();
        }

        /// <summary>
        /// Возведение числа в степень
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="power">стерень</param>
        /// <returns>число {value} в степени {power}</returns>
        public double Exponentiation(double value, int power)
        {
            double valueConst = value;
            for (var i = 2; i<=power; i++)
            {
                value *= valueConst;
            }
            return value;
        }

        public double MathPow(RadicalSign radicalSign)
        {
            double result;
            result = Math.Pow(radicalSign.GetResult(), radicalSign.GetPower());

            return result;
        }
    }
}
