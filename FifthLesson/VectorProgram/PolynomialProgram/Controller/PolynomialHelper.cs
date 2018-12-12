using PolynomialProgram.Model;
using System;
using System.Collections.Generic;

namespace PolynomialProgram.Controller
{
    public static class PolynomialHelper
    {
        public static Polynomial Sum(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();

            var maxPower = Math.Max(first.Power, second.Power);

            for (var i = 0; i <= maxPower; i++)
            {
                var firstMonomial = first.Monomials.ContainsKey(i) ? first.Monomials[i] : 0;
                var secondMonomial = second.Monomials.ContainsKey(i) ? second.Monomials[i] : 0;
                var sumMonomials = firstMonomial + secondMonomial;

                resultMonomials.Add(i, sumMonomials);
            }
            return new Polynomial(maxPower, resultMonomials);
        }

        public static Polynomial Subtract(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();

            var maxPower = Math.Max(first.Power, second.Power);

            for (var i = 0; i <= maxPower; i++)
            {
                var firstValue = first.Monomials.ContainsKey(i) ? first.Monomials[i] : 0;
                var secondValue = second.Monomials.ContainsKey(i) ? second.Monomials[i] : 0;
                var differenceMonomial = firstValue - secondValue;

                if (!differenceMonomial.IsEquals(0))
                {
                    resultMonomials.Add(i, differenceMonomial);
                }
            }
            return new Polynomial(maxPower, resultMonomials);
        }

        public static Polynomial Multiply(Polynomial first, Polynomial second)
        {
            IDictionary<int, double> resultMonomials = new Dictionary<int, double>();
            var resultMaxPower = first.Power + second.Power;
            var maxPower = Math.Max(first.Power, second.Power);

            for (var i = 0; i <= maxPower; i++)
            {
                if (!first.Monomials.ContainsKey(i))
                {
                    continue;
                }

                var firstValue = first.Monomials[i];
                for (var j = 0; j <= maxPower; j++)
                {
                    if (!second.Monomials.ContainsKey(j))
                    {
                        continue;
                    }

                    var secondValue = second.Monomials[j];
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
            var resultPolynomial = new Polynomial(polynomial);

            for (var key = 0; key <= polynomial.Power; key++)
            {
                if (polynomial.Monomials.ContainsKey(key))
                {
                    polynomial.Monomials[key] *= number;
                }
            }

            return resultPolynomial;
        }
    }
}
