﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonsMethod.Model;

namespace NewtonsMethod.Controller
{
    public class Calculation: ICalculation
    {
        /// <summary>
        /// Вычисление корня n-ой степени из числа методом Ньютона с заданной точностью
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
        /// Возведение числа в степень
        /// </summary>
        /// <param name="value">число</param>
        /// <param name="power">стерень</param>
        /// <returns>число {value} в степени {power}</returns>
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
