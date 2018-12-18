using PolynomialProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialProgram.Controller
{
    public static class PolynomialHelper
    {
        private enum Action
        {
            Sum,
            Subtraction
        }

        public static Polynomial Sum(Polynomial first, Polynomial second)
        {
            return CalculateNewPolynomial(first, second, Action.Sum);
        }

        public static Polynomial Subtract(Polynomial first, Polynomial second)
        {
            return CalculateNewPolynomial(first, second, Action.Subtraction);
        }


        private static Polynomial CalculateNewPolynomial(Polynomial first, Polynomial second, Action action)
        {
            var resultMonomials = new Dictionary<int, double>();

            var maxPower = Math.Max(first.Power, second.Power);

            for (var i = 0; i <= maxPower; i++)
            {
                var firstValue = GetCoefficient(first, i);
                var secondValue = GetCoefficient(second, i);

                var result = action == Action.Sum ? firstValue + secondValue : firstValue - secondValue;
                resultMonomials.Add(i, result);
            }

            return new Polynomial(maxPower, resultMonomials);
        }

        public static Polynomial Multiply(Polynomial first, Polynomial second)
        {
            var resultMonomials = new Dictionary<int, double>();
            var resultMaxPower = first.Power + second.Power;
            var maxPower = Math.Max(first.Power, second.Power);

            for (var i = 0; i <= maxPower; i++)
            {
                var firstValue = GetCoefficient(first, i);
                if (firstValue.IsEqual(0))
                {
                    continue;
                }
                
                for (var j = 0; j <= maxPower; j++)
                {
                    var secondValue = GetCoefficient(second, j);
                    if (secondValue.IsEqual(0))
                    {
                        continue;
                    }

                    var currentValue = firstValue * secondValue;
                    var currentPower = i + j;

                    if (resultMonomials.ContainsKey(currentPower))
                    {
                        resultMonomials[currentPower] += currentValue;
                    }
                    else
                    {
                        resultMonomials.Add(currentPower, currentValue);
                    }
                }
            }

            return new Polynomial(resultMaxPower, resultMonomials);
        }

        public static Polynomial MultiplyByConstant(Polynomial polynomial, double number)
        {
            var enumerable = polynomial.Monomials.ToDictionary(pair => pair.Key, pair => pair.Value * number);
            return new Polynomial(polynomial.Power, enumerable);
        }

        private static double GetCoefficient(Polynomial first, int i)
        {
            return first.Monomials.ContainsKey(i) ? first.Monomials[i] : 0;
        }


    }
}
